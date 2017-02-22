namespace MedWorkflow.Factories
{
    public interface IWorkflowInstanceFactory
    {
        IWorkflowInstance Create(IWorkflowTemplate template);
    }
}