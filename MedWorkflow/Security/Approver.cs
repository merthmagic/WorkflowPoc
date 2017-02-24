namespace MedWorkflow.Security
{
    public class Approver:IApprover
    {

        public string ApproverId { get; set; }

        public System.Collections.Generic.List<IApproverRole> Roles { get; set; }
    }
}