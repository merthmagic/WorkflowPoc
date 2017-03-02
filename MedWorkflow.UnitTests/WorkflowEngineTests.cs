using NUnit.Framework;

namespace MedWorkflow.UnitTests
{
    [TestFixture]
    public class WorkflowEngineTests
    {
        private IWorkflowEngine _workflowEngine;

        [SetUp]
        public void Setup()
        {
            _workflowEngine = EngineContext.Current;
            _workflowEngine.RegisterUserCredentialsProvider(new PhantomUserCredentialsProvider());
        }

        [Test]
        public void WorkflowTemplateLoadTest()
        {
            var workflowTemplate = _workflowEngine.LoadWorkflowTemplate("WFT123456");
            Assert.NotNull(workflowTemplate);
        }
    }
}