using System;
using System.Collections.Generic;

namespace MedWorkflow
{
    internal class ActivityInstance : IActivityInstance
    {
        private readonly ICollection<ActionRecord> _actionRecords = new List<ActionRecord>();

        private bool _isNew;
        private bool _isDirty;
        private readonly bool _isTransient;

        public ActivityInstance()
        {
            _isDirty = true;
            _isNew = true;
            _isTransient = false;
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
            _isDirty = true;
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
            get { return _isNew;}
        }

        public bool IsDirty
        {
            get { return _isDirty; }
        }

        public bool IsTransient
        {
            get { return _isTransient; }
        }

        public void MarkOld()
        {
            _isDirty = false;
            _isNew = false;
        }

        public string ActivityInstanceId { get; internal set; }
    }
}