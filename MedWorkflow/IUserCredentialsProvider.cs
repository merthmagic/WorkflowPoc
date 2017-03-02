using MedWorkflow.Security;

namespace MedWorkflow
{
    public interface IUserCredentialsProvider
    {
        /// <summary>
        /// 通过特定实现，获取当前的用户信息，返回审批会话
        /// </summary>
        IApprover Current { get; }
    }
}