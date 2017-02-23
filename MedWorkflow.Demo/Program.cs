using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MedWorkflow.Factories;
using MedWorkflow.Utils;

namespace MedWorkflow.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);
            var workflow = WorkflowInstanceFactory.Create(template, null, null);
            Console.ReadKey(true);
        }
    }
}
