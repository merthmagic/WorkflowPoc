namespace MedWorkflow
{
    public interface ISessionProvider
    {
        /// <summary>
        /// 通过特定实现，获取当前的用户信息，返回审批会话
        /// </summary>
        IWorkflowSession Current { get; }
    }
}