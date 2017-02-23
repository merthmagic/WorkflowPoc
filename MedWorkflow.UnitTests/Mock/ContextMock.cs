using MedWorkflow.Security;
using Moq;

namespace MedWorkflow.UnitTests.Mock
{
    public class ContextMock
    {
        public static IWorkflowExecutionContext MockExecutionContext(IApprover approver)
        {
            var contextMock = new Mock<IWorkflowExecutionContext>();
            contextMock.Setup(m => m.Approver).Returns(approver);
            return contextMock.Object;
        }
    }
}