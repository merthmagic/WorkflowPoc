using MedWorkflow.Security;

namespace MedWorkflow
{
    /// <summary>
    /// 工作流流转上下文
    /// </summary>
    public interface IWorkflowExecutionContext
    {
        IApprover Approver { get; }
    }
}