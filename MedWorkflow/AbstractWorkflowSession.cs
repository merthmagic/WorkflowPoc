namespace MedWorkflow
{
    public abstract class AbstractWorkflowSession:IWorkflowSession
    {
        protected AbstractWorkflowSession()
        {
            
        }

        public abstract Security.IApprover CurrentUser { get; }

        public IWorkflowInstance NeWorkflowInstance(IWorkflowTemplate template)
        {
            throw new System.NotImplementedException();
        }

        public void SaveInstance(IWorkflowInstance instance)
        {
            throw new System.NotImplementedException();
        }

        public IWorkflowInstance LoadWorkflowInstance(string workflowInstanceId)
        {
            throw new System.NotImplementedException();
        }
    }
}