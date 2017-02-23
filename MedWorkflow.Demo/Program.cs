using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MedWorkflow.Utils;

namespace MedWorkflow.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);
            Console.ReadKey(true);
        }
    }
}
