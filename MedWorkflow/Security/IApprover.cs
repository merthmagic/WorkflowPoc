using System.Collections.Generic;

namespace MedWorkflow.Security
{
    /// <summary>
    /// 审批者
    /// </summary>
    public interface IApprover
    {
        /// <summary>
        /// 审批用户Id
        /// </summary>
        string ApproverId { get; }

        /// <summary>
        /// 拥有的审批角色
        /// </summary>
        List<IApproverRole> Roles { get; } 
    }
}