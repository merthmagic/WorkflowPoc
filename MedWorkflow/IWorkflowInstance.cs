using System;
using System.Collections.Generic;
using MedWorkflow.Audit;
using MedWorkflow.Security;

namespace MedWorkflow
{
    /// <summary>
    /// 工作流实例
    /// </summary>
    public interface IWorkflowInstance
    {
        /// <summary>
        /// 流程实例的执行上下文
        /// </summary>
        IWorkflowExecutionContext ExecutionContext { get; }
        /// <summary>
        /// 创建此流程的工作流模板
        /// </summary>
        IWorkflowTemplate WorkflowTemplate { get; }

        /// <summary>
        /// 审批的表单
        /// </summary>
        IForm Form { get; }

        /// <summary>
        /// 审批申请人
        /// </summary>
        IApprover Owner { get; }

        /// <summary>
        /// 审批历史
        /// </summary>
        ICollection<AuditTrailEntry> AuditTrails { get; }

        /// <summary>
        /// 预设过期时间
        /// </summary>
        DateTime ExpireOn { get; }

        /// <summary>
        /// 当前节点
        /// </summary>
        IActivityInstance Current { get; }

        #region Operations
        void Submit(string comment);

        void Approve(string comment);

        void Cancel(string comment);

        void Reject(string comment);

        void Assign(AssignSpecification assignSpecification);

        void Delegate(AssignSpecification assignSpecification);
        #endregion
    }
}