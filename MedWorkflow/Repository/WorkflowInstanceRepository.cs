using System;
using System.Linq;
using MedWorkflow.Data;
using MedWorkflow.Data.Entity;
using MedWorkflow.Data.Mapper;

namespace MedWorkflow.Repository
{
    internal class WorkflowInstanceRepository
    {
        private readonly WorkflowTemplateRepository _workflowTemplateRepository;

        public WorkflowInstanceRepository(WorkflowTemplateRepository workflowTemplateRepository)
        {
            _workflowTemplateRepository = workflowTemplateRepository;
        }

        /// <summary>
        /// 载入流程实例
        /// </summary>
        /// <param name="workflowInstanceId"></param>
        /// <returns></returns>
        public IWorkflowInstance Find(string workflowInstanceId)
        {
            using (var dbContext = DbFactory.GetDbContext())
            {
                var workflowInstanceMapper = new WorkflowInstanceEntityMapper(dbContext);
                var wfInstanceEntity = workflowInstanceMapper.SelectByPrimaryKey(workflowInstanceId);

                return null;
            }
        }

        public void Save(IWorkflowInstance workflowInstance)
        {
            using (var dbContext = DbFactory.GetDbContext())
            {
                try
                {
                    if (workflowInstance.IsNew)
                        Insert(workflowInstance, dbContext);

                    else if (workflowInstance.IsDirty)
                        Update(workflowInstance, dbContext);

                    dbContext.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContext.Transaction.Rollback();
                    throw new ApplicationException("数据操作异常，事务已回滚", ex);
                }
            }
        }

        private void Insert(IWorkflowInstance workflowInstance, DbContext dbContext)
        {
            var wfInstanceMapper = new WorkflowInstanceEntityMapper(dbContext);

            var instanceEntity = new WorkflowInstanceEntity
            {
                CREATED_ON = DateTime.Now,
                LAST_UPDATED_ON = DateTime.Now,
                FORM_TYPE = workflowInstance.Form.FormType,
                FORM_ID = workflowInstance.Form.FormId,
                OWNER_ID = workflowInstance.Owner.ApproverId,
                INSTANCE_VERSION = DateTime.Now,
                STATUS = 1,
                WORKFLOW_INSTANCE_ID = workflowInstance.WorkflowInstanceId,
                WORKFLOW_TEMPLATE_ID = workflowInstance.WorkflowTemplate.TemplateUuid
            };
            wfInstanceMapper.Insert(instanceEntity);

            var bookmark = CreateBookMark(workflowInstance);

            SetBookMark(bookmark, dbContext);

            //新创建的workflow instance没有previous节点需要持久化
            SaveActivityInstance(workflowInstance.Current, workflowInstance.WorkflowInstanceId, dbContext);

            workflowInstance.MarkOld();
        }

        private WorkflowBookmarkEntity CreateBookMark(IWorkflowInstance workflowInstance)
        {
            var allowedActions = string.Join(",",
                workflowInstance.Current.ActivityTemplate.AllowedActions.Select(p => p.OperationCode.ToString())
                    .ToList());
            var bookmark = new WorkflowBookmarkEntity()
            {
                BOOKMARK_ID = Guid.NewGuid().ToString(),
                CREATED_ON = DateTime.Now,
                LAST_UPDATED_ON = DateTime.Now,
                CURRENT_ACTIVITY_NAME = workflowInstance.Current.ActivityTemplate.Name,
                NEXT_ACTIVITY_NAME = FindNextActivityTemplate(workflowInstance.Current.ActivityTemplate).Name,
                ALLOWED_OPERATIONS = allowedActions,
                FORM_TYPE = workflowInstance.Form.FormType,
                FORM_ID = workflowInstance.Form.FormId,
                WORKFLOW_INSTANCE_ID = workflowInstance.WorkflowInstanceId,
                USER_ID = workflowInstance.Owner.ApproverId
            };
            return bookmark;
        }

        private IActivityTemplate FindNextActivityTemplate(IActivityTemplate template)
        {
            return
                template.AllowedActions.First(
                    p => p.OperationCode == OperationCode.Submit || p.OperationCode == OperationCode.Submit).Transit;
        }

        private void SetBookMark(WorkflowBookmarkEntity workflowBookmarkEntity, DbContext context)
        {
            var mapper = new WorkflowBookmarkMapper(context);
            mapper.Insert(workflowBookmarkEntity);
        }

        private void SaveActivityInstance(IActivityInstance activityInstance, string workflowInstanceId, DbContext dbContext)
        {
            if (activityInstance.IsNew)
            {
                InsertActivityInstance(activityInstance, workflowInstanceId, dbContext);
                foreach (var action in activityInstance.ActionRecords)
                {
                    SaveAction(action, activityInstance.ActivityInstanceId, dbContext);
                }
            }
            else if (activityInstance.IsDirty)
                UpdateActivityInstance(activityInstance, dbContext);
        }

        private void InsertActivityInstance(IActivityInstance activityInstance, string workflowInstanceId, DbContext dbContext)
        {
            var wfActivityMapper = new ActivityInstanceMapper(dbContext);

            var activityInstanceEntity = new ActivityInstanceEntity
            {
                ACTIVITY_INSTANCE_ID = Guid.NewGuid().ToString(),
                //TODO:conflict here
                ACTIVITY_TEMPLATE_ID = activityInstance.ActivityTemplate.ActivityTemplateId.ToString(),
                CREATED_ON = DateTime.Now,
                LAST_UPDATED_ON = DateTime.Now,
                WORKFLOW_INSTANCE_ID = workflowInstanceId,
                STATUS = (int)activityInstance.Status,
                POLICY_DESCRIPTOR = "PHANTOM_DESCRIPTOR"
            };

            wfActivityMapper.Insert(activityInstanceEntity);
        }

        private void UpdateActivityInstance(IActivityInstance activityInstance, DbContext dbContext)
        {
            var wfActivityMapper = new ActivityInstanceMapper(dbContext);

            var activityInstanceEntity = new ActivityInstanceEntity
            {
                ACTIVITY_INSTANCE_ID = activityInstance.ActivityInstanceId,
                LAST_UPDATED_ON = DateTime.Now,
                STATUS = (int)activityInstance.Status,
            };

            wfActivityMapper.UpdateByPrimaryKeySelective(activityInstanceEntity);
        }

        private void SaveAction(ActionRecord actionInstance, string activityInstanceId, DbContext dbContext)
        {
            if (actionInstance.IsNew)
                InsertAction(actionInstance, activityInstanceId, dbContext);
        }

        private void InsertAction(ActionRecord actionInstance, string activityInstanceId, DbContext dbContext)
        {
            var actionRecordMapper = new ActionMapper(dbContext);
            var actionEntity = new ActionEntity
            {
                ACTION_ID = actionInstance.ActionId ?? Guid.NewGuid().ToString(),
                ACTIVITY_INSTANCE_ID = activityInstanceId,
                APPROVER_REQUIRED = "PLACEHOLDER",
                CREATED_ON = DateTime.Now,
                LAST_UPDATED_ON = DateTime.Now,
                OPERATION_CODE = "UNSET",
                REQUIRED_OPERATOR_TYPE = 1,
                REQUIRED_ROLE = actionInstance.RequiredRole
            };
            actionRecordMapper.Insert(actionEntity);
        }

        private void Update(IWorkflowInstance workflowInstance, DbContext context)
        {

            SaveActivityInstance(workflowInstance.OriginateActivity,
                workflowInstance.WorkflowInstanceId, context);
            SaveActivityInstance(workflowInstance.Current,
                workflowInstance.WorkflowInstanceId, context);
        }
    }
}