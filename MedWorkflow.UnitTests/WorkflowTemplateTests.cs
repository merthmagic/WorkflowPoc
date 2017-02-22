using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using MedWorkflow.Utils;
using NUnit.Framework;

namespace MedWorkflow.UnitTests
{

    [TestFixture]
    public class WorkflowTemplateTests
    {
        [Test]
        public void TemplateLoad()
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);
            Assert.IsNotNull(template);
            Assert.IsInstanceOf<IWorkflowTemplate>(template);
            Assert.AreEqual("123",template.TemplateUuid);
            Assert.IsNotNull(template.Activities);
        }
    }
}