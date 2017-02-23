namespace MedWorkflow
{
    public class ActivityInstance:IActivityInstance
    {
        public IActivityTemplate ActivityTemplate
        {
            get { throw new System.NotImplementedException(); }
        }

        public WorkflowStatus Status
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.DateTime CreatedOn
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.DateTime ExpireOn
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.DateTime LastUpdatedOn
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}