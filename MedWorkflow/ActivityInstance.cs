using System;
using System.Collections.Generic;

namespace MedWorkflow
{
    internal class ActivityInstance : IActivityInstance
    {
        private readonly ICollection<ActionRecord> _actionRecords = new List<ActionRecord>();
        
        public ActivityInstance()
        {
            Status = ActivityInstanceStatus.Working;
        }

        public IActivityTemplate ActivityTemplate { get; set; }

        public ActivityInstanceStatus Status { get; private set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ExpireOn { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public void MarkFinish()
        {
            Status = ActivityInstanceStatus.Finished;
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

        public bool IsNew
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDirty
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsTransient
        {
            get { throw new NotImplementedException(); }
        }
    }
}