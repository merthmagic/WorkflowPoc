using System;
using Dapper;
using MedWorkflow.Data;
using MedWorkflow.Exceptions;

namespace MedWorkflow.Repository
{
    public class WorkflowInstanceRepository:IWorkflowInstanceRepository
    {
        private readonly IWorkflowTemplateRepository _workflowTemplateRepository;

        public WorkflowInstanceRepository(IWorkflowTemplateRepository workflowTemplateRepository)
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
            //TODO:从存储读取实例的信息
            var workflowTemplateId = "tobedecide";
            var workflowTemplate = _workflowTemplateRepository.Find(workflowTemplateId);
            if(workflowTemplate == null)
                throw new IllegalStateException();
            var workflowInstance = new WorkflowInstance(workflowTemplate,null,null);

            workflowInstance.MarkOld();

            return workflowInstance;
        }

        public void Save(IWorkflowInstance workflowInstance)
        {
            //需要先判断数据版本

            //TODO: implement it
        }
    }
}