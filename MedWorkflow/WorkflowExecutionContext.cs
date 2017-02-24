namespace MedWorkflow
{
    public class WorkflowExecutionContext:IWorkflowExecutionContext
    {
        public Security.IApprover Approver { get; set; }
    }
}