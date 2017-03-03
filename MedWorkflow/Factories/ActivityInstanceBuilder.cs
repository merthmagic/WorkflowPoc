using System;
using System.Collections.Generic;

namespace MedWorkflow.Factories
{
    internal class ActivityInstanceBuilder
    {
        private readonly IActivityTemplate _activityTemplate;
        private List<ActionRecord> _actionRecords;
        private readonly ActivityInstance _instance;

        public ActivityInstanceBuilder(IActivityTemplate activityTemplate)
        {
            _activityTemplate = activityTemplate;
            _instance = new ActivityInstance
            {
                ActivityTemplate = _activityTemplate,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
                ActivityInstanceId = Guid.NewGuid().ToString()
            };
        }

        public ActivityInstance Build()
        {
            
            if(_actionRecords != null && _actionRecords.Count>0)
                _actionRecords.ForEach(p=>_instance.AddAction(p));
            
            return _instance;
        }

        public ActivityInstanceBuilder Set(List<ActionRecord> actionRecords)
        {
            _actionRecords = actionRecords;
            return this;
        }

        public void InitializeFirstAction()
        {
            var actionRecord = new ActionRecord();            
            _actionRecords.Add(actionRecord);
        }
    }
}