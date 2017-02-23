using System.Collections.Generic;
using MedWorkflow.Security;
using Moq;

namespace MedWorkflow.UnitTests.Mock
{
    public class ApproverMock
    {
        public static IApprover MockApprover(string approverId, List<IApproverRole> roles)
        {
            var approverMock = new Mock<IApprover>();
            approverMock.Setup(m => m.ApproverId).Returns("admin");
            approverMock.Setup(m => m.Roles).Returns(new List<IApproverRole>());
            return approverMock.Object;
        }

        public static IApproverRole MockApproverRole(string id, string name, string description)
        {
            var roleMock = new Mock<IApproverRole>();
            roleMock.Setup(m => m.Id).Returns(id);
            roleMock.Setup(m => m.Name).Returns(name);
            roleMock.Setup(m => m.Description).Returns(description);
            return roleMock.Object;
        }
    }
}