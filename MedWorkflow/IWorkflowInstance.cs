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
        List<AuditTrailEntry> AuditTrails { get; }

        /// <summary>
        /// 预设过期时间
        /// </summary>
        DateTime ExpireOn { get; }
    }
}