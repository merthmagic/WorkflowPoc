using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
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
            var query = from item in root.Element("Activities").Elements("Activity")
                        select BuildActivityTemplate(workflowTemplate, item);

            //流程节点加入到流程模板中，此时双向引用完成
            workflowTemplate.AddActivityTemplates(query);

            return workflowTemplate;
        }

        private static IActivityTemplate BuildActivityTemplate(IWorkflowTemplate workflowTemplate, XElement element)
        {
            var activityTemplate = new ActivityTemplate(workflowTemplate);
            var activityTemplateId = Convert.ToInt32(element.Attribute("id"));
            var activityTemplateName = element.Element("Name").Value;
            var actionElements = element.Elements("Actions");
            foreach (var actionElem in actionElements)
            {
                var operation = (OperationCode)Enum.Parse(typeof(OperationCode), actionElem.Attribute("operationCode").Value);
                var transitTo = 0;
                if (actionElem.Attribute("transit") != null)
                {
                    transitTo = Convert.ToInt32(actionElem.Attribute("transit").Value);
                }
                MedWorkflow.Action action = new Action(operation, transitTo);
            }
            return activityTemplate;
        }
    }
}