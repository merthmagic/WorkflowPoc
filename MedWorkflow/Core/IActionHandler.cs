namespace MedWorkflow.Core
{
    public interface IActionHandler
    {
        void Execute(ExecutionContext context);
    }
}