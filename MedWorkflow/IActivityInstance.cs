using System;
using MedWorkflow.Security;

namespace MedWorkflow
{
    public interface IActivityInstance
    {
        /// <summary>
        /// 创建当前实例的工作流模板
        /// </summary>
        IWorkflowTemplate WorkflowTemplate { get; }

        
        /// <summary>
        /// 流程当前状态
        /// </summary>
        WorkflowStatus Status { get; }

        /// <summary>
        /// 流程创建时间
        /// </summary>
        DateTime CreatedOn { get; }

        /// <summary>
        /// 流程过期时间
        /// </summary>
        DateTime ExpireOn { get; }

        /// <summary>
        /// 流程最后修改时间
        /// </summary>
        DateTime LastUpdatedOn { get; }

        /// <summary>
        /// 流程创建者
        /// </summary>
        IApprover Owner { get; }
    }
}