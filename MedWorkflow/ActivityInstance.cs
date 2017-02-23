using System.Collections.Generic;

namespace MedWorkflow
{
    internal class ActivityInstance : IActivityInstance
    {
        private ActivityInstanceStatus _status;
        private ICollection<ActionRecord> _actionRecords = new List<ActionRecord>();

        public ActivityInstance()
        {
            _status = ActivityInstanceStatus.Working;
        }

        public IActivityTemplate ActivityTemplate { get; set; }

        public ActivityInstanceStatus Status
        {
            get
            {
                return _status;
            }
        }

        public System.DateTime CreatedOn { get; set; }

        public System.DateTime ExpireOn { get; set; }

        public System.DateTime LastUpdatedOn { get; set; }

        public void MarkFinish()
        {
            _status = ActivityInstanceStatus.Finished;
        }


        public IEnumerable<ActionRecord> ActionRecords
        {
            get { return _actionRecords; }
        }


        public ActionRecord Tail { get; private set; }

        public void AddAction(ActionRecord record)
        {
            _actionRecords.Add(record);
        }
    }
}