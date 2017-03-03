using System;
using System.Configuration;

namespace MedWorkflow.Data.Entity
{
    public class WorkflowInstanceEntity
    {

        public string WORKFLOW_INSTANCE_ID { get; set; }

        public int STATUS { get; set; }

        public DateTime CREATED_ON { get; set; }

        public DateTime LAST_UPDATED_ON { get; set; }

        public string WORKFLOW_TEMPLATE_ID { get; set; }

        public DateTime INSTANCE_VERSION { get; set; }

        public string FORM_TYPE { get; set; }

        public string FORM_ID { get; set; }

        public string OWNER_ID { get; set; }
    }
}