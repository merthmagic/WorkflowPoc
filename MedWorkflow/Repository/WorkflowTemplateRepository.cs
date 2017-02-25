using System;
using System.Collections.Generic;
using MedWorkflow.Exceptions;

namespace MedWorkflow.Repository
{
    public class WorkflowTemplateRepository
    {
        private readonly Dictionary<string, IWorkflowTemplate> _workflowTemplates;

        public WorkflowTemplateRepository()
        {
            _workflowTemplates = new Dictionary<string, IWorkflowTemplate>();
        }

        public IWorkflowTemplate Find(string workflowTemplateId)
        {
            if (_workflowTemplates.ContainsKey(workflowTemplateId)) return _workflowTemplates[workflowTemplateId];
            var template = DoLoadTemplate(workflowTemplateId);
            if (template == null)
                throw new IllegalStateException();
            _workflowTemplates.Add(workflowTemplateId, template);
            return _workflowTemplates[workflowTemplateId];
        }

        private IWorkflowTemplate DoLoadTemplate(string workflowTemplateId)
        {
            throw new NotImplementedException();
        }
    }
}