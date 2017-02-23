namespace MedWorkflow.Repository
{
    public interface IWorkflowTemplateRepository
    {
        IWorkflowTemplate Find(string workflowTemplateId);
    }
}