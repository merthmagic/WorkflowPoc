using System.Collections.Generic;
using MedWorkflow.Data;
using MedWorkflow.Data.Mapper;
using MedWorkflow.Factories;
using MedWorkflow.Repository;
using MedWorkflow.Security;

namespace MedWorkflow
{
    internal class DefaultWorkflowSession : AbstractWorkflowSession
    {
        private readonly WorkflowInstanceRepository _workflowInstanceRepository;

        public DefaultWorkflowSession()
        {
            var workflowTemplateRepository  = new WorkflowTemplateRepository();
            _workflowInstanceRepository = new WorkflowInstanceRepository(workflowTemplateRepository);
        }

        public override IApprover CurrentUser
        {
            get { return EngineContext.Current.RegisteredUserCredentialsProviderProvider.Current; }
        }

        public override void SaveInstance(IWorkflowInstance instance)
        {
            _workflowInstanceRepository.Save(instance);
        }

        public override IWorkflowInstance LoadWorkflowInstance(string workflowInstanceId)
        {
            return _workflowInstanceRepository.Find(workflowInstanceId);
        }

        public override IWorkflowInstance NewWorkflowInstance(IWorkflowTemplate template, string formType, string formId)
        {
            var instance = WorkflowInstanceFactory.Create(template, new Form(formType, formId), CurrentUser,
                new WorkflowExecutionContext() { Approver = CurrentUser });
            return instance;
        }

        public override IEnumerable<IWorkflowInstance> TodoList
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}