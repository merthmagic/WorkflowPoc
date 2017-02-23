using System.Collections.Generic;
using System.IO;
using System.Text;
using MedWorkflow.Factories;
using MedWorkflow.Security;
using MedWorkflow.UnitTests.Mock;
using MedWorkflow.Utils;
using Moq;
using NUnit.Framework;

namespace MedWorkflow.UnitTests
{
    [TestFixture]
    public class ProcessTests
    {
        private IApprover _approver;

        [SetUp]
        public void Prepare()
        {
            var role = ApproverMock.MockApproverRole("1", "HR", "lorem ipsum");
            _approver = ApproverMock.MockApprover("1", new List<IApproverRole>() { role });
        }

        [Test]
        public void CreateInstanceAndSubmit()
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);
            var context = ContextMock.MockExecutionContext(_approver);
            var workflow = WorkflowInstanceFactory.Create(template, null,_approver,context);

            Assert.NotNull(workflow);
            workflow.Submit("some description");
            Assert.AreEqual(true, workflow.AuditTrails.Count > 0);
        }
    }
}