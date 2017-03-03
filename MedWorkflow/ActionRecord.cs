namespace MedWorkflow
{
    /// <summary>
    /// 操作记录，用于描述流程实例的执行具体步骤
    /// </summary>
    public class ActionRecord
    {
        public ActionRecord()
        {
            IsNew = true;
            IsDirty = true;
        }

        public bool Finished { get; private set; }

        public bool IsNew { get; private set; }

        public bool IsDirty { get; private set; }

        public void MarkFinished()
        {
            Finished = true;
        }

        public void MarkOld()
        {
            IsDirty = false;
        }

        public string ActivityInstanceId { get; internal set; }

        public string RequiredRole { get; set; }

        public string RequiredApprover { get; set; }

        public string ActionId { get; internal set; }
    }
}