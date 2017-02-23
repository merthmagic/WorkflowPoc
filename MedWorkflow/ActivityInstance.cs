namespace MedWorkflow
{
    internal class ActivityInstance : IActivityInstance
    {
        public IActivityTemplate ActivityTemplate { get; set; }

        public ActivityInstanceStatus Status { get; private set; }

        public System.DateTime CreatedOn { get; set; }

        public System.DateTime ExpireOn { get; set; }

        public System.DateTime LastUpdatedOn { get; set; }

        public void MarkFinish()
        {
            Status = ActivityInstanceStatus.Finished;
        }


        public System.Collections.Generic.IEnumerable<ActionRecord> ActionRecords { get; set; }


        public ActionRecord Tail { get; private set; }

        public void AddAction(ActionRecord record)
        {
            throw new System.NotImplementedException();
        }
    }
}