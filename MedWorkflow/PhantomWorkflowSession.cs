using System.Collections.Generic;
using MedWorkflow.Factories;
using MedWorkflow.Security;

namespace MedWorkflow
{
    public class PhantomWorkflowSession : AbstractWorkflowSession
    {
        public override IApprover CurrentUser
        {
            get
            {
                var approver = new Approver {ApproverId = "admin123"};
                approver.Roles.AddRange(new List<ApproverRole>()
                {
                    new ApproverRole(){Id = "1",Name = "admin"}
                });
                return approver;
            }
        }
    }
}