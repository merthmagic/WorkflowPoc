using System.Collections.Generic;
using System.IO;
using System.Text;
using MedWorkflow.Factories;
using MedWorkflow.Security;
using MedWorkflow.Utils;
using Moq;
using NUnit.Framework;

namespace MedWorkflow.UnitTests
{
    [TestFixture]
    public class WorkflowInstanceTests
    {
        private IApprover _approver;
        private IForm _form;

        [SetUp]
        public void Init()
        {
            var approver = new Mock<IApprover>();
            approver.Setup(m => m.ApproverId).Returns("100");
            approver.Setup(m => m.Roles).Returns(new List<IApproverRole>());
            _approver = approver.Object;

            var form = new Mock<IForm>();
            form.Setup(m => m.FormId).Returns("200");
            form.Setup(m => m.FormType).Returns("UnitTest");
            _form = form.Object;
        }

        [Test]
        public void WorkflowInstanceCreation()
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);
            var workflow = WorkflowInstanceFactory.Create(template, _form, _approver);
            Assert.NotNull(workflow);
            Assert.NotNull(workflow.WorkflowTemplate);
            Assert.AreEqual(template,workflow.WorkflowTemplate);
            Assert.AreEqual(_form,workflow.Form);
            Assert.AreEqual(_approver,workflow.Owner);
        }
    }
}