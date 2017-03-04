using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using MedWorkflow.Security;
using System.Web;

namespace MedWorkflow.Web
{
    public class HttpUserCredentialsProvider:IUserCredentialsProvider
    {
        public Security.IApprover Current
        {
            get { return GetLogonApprover(); }
        }

        private IApprover GetLogonApprover()
        {
            if (!HttpContext.Current.Request.IsAuthenticated)
                throw new AuthenticationException();
            var userId = HttpContext.Current.User.Identity.Name;

            return new Approver()
            {
                ApproverId = userId,
                Roles = new List<IApproverRole>()
            };
        }
    }
}
