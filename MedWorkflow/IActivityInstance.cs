using System;
using System.Collections.Generic;
using MedWorkflow.Security;

namespace MedWorkflow
{
    public interface IActivityInstance:IBusinessBase
    {
        IActivityTemplate ActivityTemplate { get; }

        /// <summary>
        /// 流程当前状态
        /// </summary>
        ActivityInstanceStatus Status { get; }

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
        /// 标记节点实例完成
        /// </summary>
        void MarkFinish();

        /// <summary>
        /// Action集合
        /// </summary>
        IEnumerable<ActionRecord> ActionRecords { get; }

        ActionRecord Tail { get; }

        void AddAction(ActionRecord record);
    }
}