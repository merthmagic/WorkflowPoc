namespace MedWorkflow.Audit
{
    /// <summary>
    /// 审批记录
    /// </summary>
    public class AuditTrailEntry
    {
        public string OperatorId { get; internal set; }

        public string WorkflowInstanceId { get; internal set; }



        internal bool IsNew { get; set; }
    }
}