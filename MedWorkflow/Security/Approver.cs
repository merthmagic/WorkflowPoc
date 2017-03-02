namespace MedWorkflow.Security
{
    public class Approver:IApprover
    {

        public string ApproverId { get; set; }

        public System.Collections.Generic.List<IApproverRole> Roles { get; set; }

        public override int GetHashCode()
        {
            return ApproverId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var instance = obj as IApprover;
            if (instance != null)
            {
                return ApproverId == instance.ApproverId;
            }
            return false;
        }
    }
}