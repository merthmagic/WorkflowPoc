namespace MedWorkflow.Security
{
    public interface IApproverRole
    {
        /// <summary>
        /// 审批角色唯一标识
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 详情
        /// </summary>
        string Description { get; }
    }
}