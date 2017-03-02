using System.Collections.Generic;
using MedWorkflow.Factories;
using MedWorkflow.Security;

namespace MedWorkflow
{
    internal class DefaultWorkflowSession : AbstractWorkflowSession
    {
        public override IApprover CurrentUser
        {
            get { return EngineContext.Current.RegisteredUserCredentialsProviderProvider.Current; }
        }

        public override void SaveInstance(IWorkflowInstance instance)
        {
            throw new System.NotImplementedException();
        }

        public override IWorkflowInstance LoadWorkflowInstance(string workflowInstanceId)
        {
            throw new System.NotImplementedException();
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