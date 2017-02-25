using System;

namespace MedWorkflow.Data.Entity
{
    public class ActionEntity
    {
        public string ACTION_ID { get; set; }

        public string ACTIVITY_INSTANCE_ID { get; set; }

        public string OPERATION_CODE { get; set; }

        public string REQUIRED_ROLE { get; set; }

        public int REQUIRED_OPERATOR_TYPE { get; set; }

        public int STATUS { get; set; }

        public DateTime CREATED_ON { get; set; }

        public DateTime LAST_UPDATED_ON { get; set; }

        public string APPROVER_REQUIRED { get; set; }
    }
}