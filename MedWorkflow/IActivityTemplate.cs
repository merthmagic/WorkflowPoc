using System.Collections.Generic;
using MedWorkflow.Security;

namespace MedWorkflow
{
    public interface IActivityTemplate
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// ActivityTemplate的唯一标识
        /// </summary>
        int ActivityTemplateId { get; }

        /// <summary>
        /// Activity所属的工作流模板
        /// </summary>
        IWorkflowTemplate WorkflowTemplate { get; }

        /// <summary>
        /// 是否起始节点
        /// </summary>
        bool BeginActivity { get; }

        /// <summary>
        /// 是否最终节点
        /// </summary>
        bool FinalActivity { get; }

        /// <summary>
        /// 当前节点的审批策略
        /// </summary>
        IApprovalPolicy ApprovalPolicy { get; }

        /// <summary>
        /// 允许的操作
        /// </summary>
        IEnumerable<IAction> AllowedActions { get; }

        /// <summary>
        /// 审批所需角色
        /// </summary>
        IApproverRole RequiredRole { get; }
    }
}      