using System.IO;
using System.Text;
using MedWorkflow.Factories;
using MedWorkflow.Utils;
using NUnit.Framework;

namespace MedWorkflow.UnitTests
{
    [TestFixture]
    public class WorkflowInstanceTests
    {
        [Test]
        public void WorkflowInstanceCreation()
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);
            var workflow = WorkflowInstanceFactory.Create(template, null, null);
            Assert.NotNull(workflow);
            Assert.NotNull(workflow.WorkflowTemplate);
            Assert.AreEqual(template,workflow.WorkflowTemplate);
        }
    }
}