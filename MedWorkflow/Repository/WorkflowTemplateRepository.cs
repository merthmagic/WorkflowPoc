using System;
using System.Collections.Generic;
using MedWorkflow.Exceptions;
using MedWorkflow.Utils;

namespace MedWorkflow.Repository
{
    public class WorkflowTemplateRepository
    {
        private readonly Dictionary<string, IWorkflowTemplate> _cachedWorkflowTemplates;

        public WorkflowTemplateRepository()
        {
            _cachedWorkflowTemplates = new Dictionary<string, IWorkflowTemplate>();
        }

        public IWorkflowTemplate Find(string workflowTemplateId)
        {
            if (_cachedWorkflowTemplates.ContainsKey(workflowTemplateId)) return _cachedWorkflowTemplates[workflowTemplateId];
            var template = DoLoadTemplate(workflowTemplateId);
            if (template == null)
                throw new IllegalStateException();
            _cachedWorkflowTemplates.Add(workflowTemplateId, template);
            return _cachedWorkflowTemplates[workflowTemplateId];
        }

        private IWorkflowTemplate DoLoadTemplate(string workflowTemplateId)
        {
            //TODO:replace the mock implmentation
            return XmlWorkflowTemplateParser.Parse(@"d:\WorkflowTemplatePoc.xml");
        }
    }
}