using System.Collections.Generic;
using MedWorkflow.Security;

namespace MedWorkflow
{
    public class PhantomUserCredentialsProvider:IUserCredentialsProvider
    {
        private readonly IApprover _approver;

        public PhantomUserCredentialsProvider()
        {
            _approver = new Approver()
            {
                ApproverId = "admin123",
                Roles = new List<IApproverRole>()
                {
                    new ApproverRole()
                    {
                        Description = "测试角色",
                        Id = "1",
                        Name = "WfSudo"
                    }
                }
            };
        }

        public IApprover Current
        {
            get { return _approver;}
        }
    }
}