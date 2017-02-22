using System;

namespace MedWorkflow
{
    /// <summary>
    /// 操作类型
    /// </summary>
    [Flags]
    public enum OperationCode
    {
        /// <summary>
        /// 通过
        /// </summary>
        Approve,
        /// <summary>
        /// 驳回
        /// </summary>
        Reject,
        /// <summary>
        /// 分配
        /// </summary>
        Assign,
        /// <summary>
        /// 委托审批
        /// </summary>
        Delegate,
        /// <summary>
        /// 提交审批申请
        /// </summary>
        Submit
    }
}