using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using MedWorkflow.Factories;
using MedWorkflow.Security;

// ReSharper disable PossibleNullReferenceException

namespace MedWorkflow.Utils
{
    public class XmlWorkflowTemplateParser
    {
        private const int DefaultTemplateStatus = 1;

        /// <summary>
        /// 从字符串解析
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IWorkflowTemplate ParseFromString(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentException();

            var stream = PrepareStream(xml);

            var xdoc = XDocument.Load(stream);

            return DoParse(xdoc);
        }

        /// <summary>
        /// 从文件解析
        /// </summary>
        /// <param name="uri">XML文件路径</param>
        /// <returns></returns>
        public static IWorkflowTemplate Parse(string uri)
        {
            var xdoc = XDocument.Load(uri);
            return DoParse(xdoc);
        }

        private static Stream PrepareStream(string source)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.UTF8);
            streamWriter.Write(source);
            streamWriter.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="xdoc"></param>
        /// <returns></returns>
        private static IWorkflowTemplate DoParse(XDocument xdoc)
        {
            if (xdoc == null)
                throw new ArgumentException();

            var root = xdoc.Element("WorkflowTemplate");

            var templateUuid = root.Element("Identifier").Value;
            //创建WorkflowTemplate对象
            var workflowTemplate = new WorkflowTemplate(templateUuid, DefaultTemplateStatus, null);

            //构建ActivityTemplates
            //注意Lambda表达式造成的deferred execution，可能是造成部分内部空指针的原因
            var query = from item in root.Element("Activities").Elements("Activity")
                        select BuildActivityTemplate(item);

            var builder = new WorkflowTemplateBuilder();

            return builder.SetActivityTemplates(query.ToList())
                .SetWorkflowTemplate(workflowTemplate)
                .Build();
        }

        private static ActivityTemplate BuildActivityTemplate(XElement element)
        {
            var activityTemplate = new ActivityTemplate();
            var activityTemplateId = Convert.ToInt32(element.Attribute("id").Value);
            var activityTemplateName = element.Element("Name").Value;

            activityTemplate.ActivityTemplateId = activityTemplateId;
            activityTemplate.Name = activityTemplateName;
            activityTemplate.RequiredRole = new ApproverRole()
            {
                Id = "role123",
                Name = "测试角色",
                Description = "仅用于测试"
            };
            var actionElements = element.Elements("Actions");
            foreach (var actionElem in actionElements.Elements("Action"))
            {
                var operation = (OperationCode)Enum.Parse(typeof(OperationCode), actionElem.Attribute("operationCode").Value);
                var transitTo = 0;
                if (actionElem.Attribute("transit") != null)
                {
                    transitTo = Convert.ToInt32(actionElem.Attribute("transit").Value);
                }
                var action = new Action(operation, transitTo);
                activityTemplate.Actions.Add(action);
            }
            return activityTemplate;
        }
    }
}