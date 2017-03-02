using System;
using Dapper;
using MedWorkflow.Data;
using MedWorkflow.Exceptions;

namespace MedWorkflow.Repository
{
    internal class WorkflowInstanceRepository
    {
        private readonly WorkflowTemplateRepository _workflowTemplateRepository;

        private readonly DbContext _dbContext;

        public WorkflowInstanceRepository(WorkflowTemplateRepository workflowTemplateRepository,DbContext dbContext)
        {
            _workflowTemplateRepository = workflowTemplateRepository;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 载入流程实例
        /// </summary>
        /// <param name="workflowInstanceId"></param>
        /// <returns></returns>
        public IWorkflowInstance Find(string workflowInstanceId)
        {
            //TODO:从存储读取实例的信息
            var workflowTemplateId = "tobedecide";
            var workflowTemplate = _workflowTemplateRepository.Find(workflowTemplateId);
            if(workflowTemplate == null)
                throw new IllegalStateException();
            var workflowInstance = new WorkflowInstance(workflowTemplate,null,null);

            workflowInstance.MarkOld();

            return workflowInstance;
        }

        public void Save(WorkflowInstance workflowInstance)
        {
            
        }
    }
}