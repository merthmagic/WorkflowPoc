using System;

namespace MedWorkflow.Data.Entity
{
    public class WorkflowInstanceEntity
    {
        public string WORKFLOW_INSTANCE_ID { get; set; }

        public int STATUS { get; set; }

        public DateTime CREATED_ON { get; set; }

        public string WORKFLOW_TEMPLATE_ID { get; set; }

        public string OWNER_ID { get; set; }
    }
}