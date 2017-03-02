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

        [Test]
        public void WorkflowInstanceCreationTest()
        {
            var workflowTemplate = _workflowEngine.LoadWorkflowTemplate("WFT123456");
            var session = _workflowEngine.NewSession();
            var instance = session.NewWorkflowInstance(workflowTemplate, "CONTRACT", "123");
            Assert.NotNull(instance);
            Assert.AreEqual(workflowTemplate,instance.WorkflowTemplate);
        }
    }
}