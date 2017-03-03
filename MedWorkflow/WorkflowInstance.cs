using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MedWorkflow.Audit;
using MedWorkflow.Configurations;
using MedWorkflow.Exceptions;
using MedWorkflow.Factories;
using MedWorkflow.Security;

namespace MedWorkflow
{
    /// <summary>
    /// 工作流实例的内部默认实现
    /// <remarks>工作流业务聚合根</remarks>
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class WorkflowInstance :IWorkflowInstance
    {
        private readonly IWorkflowTemplate _workflowTemplate;
        private readonly IForm _form;
        private readonly IApprover _owner;
        private ICollection<AuditTrailEntry> _auditTrailEntries;
        private readonly WorkflowExecutionContext _executionContext;
        private bool _isDirty = true;
        private bool _isNew = true;
        private IActivityInstance _originateActivityInstance;

        public WorkflowInstance(IWorkflowTemplate workflowTemplate, IForm form, IApprover owner, WorkflowExecutionContext context)
        {
            WorkflowInstanceId = Guid.NewGuid().ToString();
            _workflowTemplate = workflowTemplate;
            _form = form;
            _owner = owner;
            _executionContext = context;
            _isNew = true;
        }

        public WorkflowInstance(IWorkflowTemplate workflowTemplate, IForm form, WorkflowExecutionContext context)
        {
            WorkflowInstanceId = Guid.NewGuid().ToString();
            _workflowTemplate = workflowTemplate;
            _form = form;
            _executionContext = context;
            _isNew = true;
        }

        public string WorkflowInstanceId { get; internal set; }


        public IWorkflowTemplate WorkflowTemplate
        {
            get { return _workflowTemplate; }
        }

        public IForm Form
        {
            get { return _form; }
        }

        public IApprover Owner
        {
            get { return _owner; }
        }

        public ICollection<AuditTrailEntry> AuditTrails
        {
            get { return _auditTrailEntries ?? (_auditTrailEntries = new List<AuditTrailEntry>()); }
        }

        public DateTime ExpireOn
        {
            get { return DateTime.MaxValue; }
        }

        public long InstanceVersion { get; set; }

        public IActivityInstance Current { get; set; }

        public IActivityInstance OriginateActivityInstance
        {
            get
            {
                return _originateActivityInstance;
            }
        }

        public WorkflowExecutionContext ExecutionContext
        {
            get { return _executionContext; }
        }

        private static void AssertOperation(IActivityInstance activityInstance, OperationCode operationCode)
        {
            if (activityInstance.ActivityTemplate.AllowedActions.All(p => p.OperationCode != operationCode))
                throw new InvalidOperationException("当前节点不允许此操作");
        }

        private void AssertPrivilege(IActivityInstance activityInstance)
        {
            if (EnvConfiguration.PermissionCheckOff)
                return;

            if (!_executionContext.Approver.Roles.Contains(activityInstance.ActivityTemplate.RequiredRole))
                throw new IllegalStateException("用户无权限进行此操作");
        }

        private static IAction GetCurrentAction(IActivityInstance activityInstance, OperationCode operationCode)
        {
            var ret = activityInstance.ActivityTemplate.AllowedActions.FirstOrDefault(p => p.OperationCode == operationCode);
            if (ret == null)
                throw new IllegalStateException("未能获取对应的Action信息");
            return ret;
        }

        private static ActivityInstance NewActivityInstance(IActivityTemplate activityTemplate)
        {
            var builder = new ActivityInstanceBuilder(activityTemplate);
            return builder.Build();
        }

        #region Operations
        public void Submit(string comment)
        {
            AssertOperation(Current, OperationCode.Submit);
            //提交时不进行权限验证，后面可能要加上，某些用户可能不具备提交特定流程的权限
            //AssertPrivilege(Current);

            var action = GetCurrentAction(Current, OperationCode.Submit);

            //判断是否本节点回环
            if (action.Transit.ActivityTemplateId != Current.ActivityTemplate.ActivityTemplateId)
            {
                //非本节点回环，创建下个节点实例
                var nextActivityInstance = NewActivityInstance(action.Transit);

                //标记该Activity已完成
                _originateActivityInstance = Current;
                _originateActivityInstance.MarkFinish();
                //_originateActivityInstance.Tail.MarkFinished();

                //替换当前节点
                Current = nextActivityInstance;
            }

            //相应的创建Action实例
            var actionRecord = new ActionRecord();
            Current.AddAction(actionRecord);

            //当前节点替换
            var auditTrail = new AuditTrailEntry() { IsNew = true };
            //添加审核日志
            AuditTrails.Add(auditTrail);

            _isDirty = true;
        }

        public void Approve(string comment)
        {
            AssertOperation(Current, OperationCode.Approve);
            AssertPrivilege(Current);

            //构建下一个Activity Instance
            var activityTemplate = Current.ActivityTemplate.AllowedActions.FirstOrDefault(p => p.OperationCode == OperationCode.Approve)
                .Transit;
            var nextActivityInstance = NewActivityInstance(activityTemplate);

            _originateActivityInstance = Current;
            _originateActivityInstance.MarkFinish();

            Current = nextActivityInstance;

            _isDirty = true;
        }

        public void Cancel(string comment)
        {
            AssertOperation(Current, OperationCode.Cancel);
            AssertPrivilege(Current);
            //TODO: implement
        }

        public void Reject(string comment)
        {
            AssertOperation(Current, OperationCode.Reject);
            AssertPrivilege(Current);

            var activityTemplate = Current.ActivityTemplate.AllowedActions.FirstOrDefault(p => p.OperationCode == OperationCode.Reject)
                .Transit;
            var nextActivityInstance = NewActivityInstance(activityTemplate);
            _originateActivityInstance = Current;
            Current = nextActivityInstance;
        }

        public void Assign(AssignSpecification assignSpecification)
        {
            AssertOperation(Current, OperationCode.Assign);
            AssertPrivilege(Current);
            //TODO: implement
        }

        public void Delegate(AssignSpecification assignSpecification)
        {
            AssertOperation(Current, OperationCode.Delegate);
            AssertPrivilege(Current);
            //TODO: implement
        }
        #endregion

        public bool IsNew
        {
            get { return _isNew; }
        }

        public bool IsTransient
        {
            get { return false; }
        }

        public bool IsDirty { get { return _isDirty; } }

        public void MarkOld()
        {
            _isNew = false;
            _isDirty = false;

            _originateActivityInstance.MarkOld();
            Current.MarkOld();
        }

        public override string ToString()
        {
            return string.Format("WorkflowInstance<Uid:{0}>", WorkflowInstanceId);
        }

        public override int GetHashCode()
        {
            return WorkflowInstanceId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var instance = obj as WorkflowInstance;
            if (instance != null)
            {
                return WorkflowInstanceId == instance.WorkflowInstanceId;
            }
            return false;
        }
    }
}