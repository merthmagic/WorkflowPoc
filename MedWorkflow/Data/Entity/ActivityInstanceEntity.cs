using System;

namespace MedWorkflow.Data.Entity
{
    public class ActivityInstanceEntity
    {
        public string ACTIVITY_INSTANCE_ID { get; set; }

        public string ACTIVITY_TEMPLATE_ID { get; set; }

        public int STATUS { get; set; }

        public string WORKFLOW_INSTANCE_ID { get; set; }

        public DateTime CREATED_ON { get; set; }

        public DateTime LAST_UPDATED_ON { get; set; }

        public string POLICY_DESCRIPTOR { get; set; }
    }
}