using System;

namespace MedWorkflow
{
    internal class Action:IAction
    {
        private readonly int _targetActivityId;
        private readonly OperationCode _operation;

        public Action(OperationCode operation, int targetActivityId)
        {
            _targetActivityId = targetActivityId;
            _operation = operation;
        }

        public OperationCode OperationCode { get { return _operation; }}

        public IActivityTemplate Transit
        {
            get
            {
                if(LocateActivity == null)
                    throw new InvalidOperationException("Activity locator method not specified.");

                return LocateActivity(_targetActivityId);
            }
        }

        public Func<int, IActivityTemplate> LocateActivity { get; set; } 
    }
}