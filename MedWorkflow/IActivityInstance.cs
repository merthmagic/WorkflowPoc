using System;
using System.Collections.Generic;
using MedWorkflow.Security;

namespace MedWorkflow
{
    public interface IActivityInstance
    {
        IActivityTemplate ActivityTemplate { get; }

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
    }
}