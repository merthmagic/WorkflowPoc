using NUnit.Framework;

namespace MedWorkflow.UnitTests
{
    [TestFixture]
    public class EngineContextTests
    {
        [Test]
        public void WorkflowEngileAccessibility()
        {
            var engine = EngineContext.Current;
            Assert.IsNotNull(engine);
            Assert.IsInstanceOf<IWorkflowEngine>(engine);
        }

        [Test]
        public void EngineIntialization()
        {
            var engine = EngineContext.Current;
            engine.RegisterUserCredentialsProvider(new PhantomUserCredentialsProvider());
            var session = engine.NewSession();
            var user = session.CurrentUser;
            Assert.IsNotNull(user);
            Assert.AreEqual("admin123",user.ApproverId);
            Assert.IsNotNull(user.Roles);
            Assert.AreEqual(1,user.Roles.Count);
        }
    }
}