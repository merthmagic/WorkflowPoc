using MedWorkflow.Security;

namespace MedWorkflow
{
    /// <summary>
    /// 审批流会话
    /// </summary>
    public interface IWorkflowSession
    {
        IApprover CurrentUser { get; }

        IWorkflowInstance NeWorkflowInstance(IWorkflowTemplate template,string formType,string formId);

        void SaveInstance(IWorkflowInstance instance);

        IWorkflowInstance LoadWorkflowInstance(string workflowInstanceId);
    }
}