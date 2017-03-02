using System;
using System.Collections.Generic;
using MedWorkflow.Repository;

namespace MedWorkflow
{
    /// <summary>
    /// 默认工作流引擎
    /// </summary>
    internal class WorkFlowEngine : IWorkflowEngine
    {
        private ISessionProvider _sessionProvider;

        private readonly WorkflowTemplateRepository _workflowTemplateRepository;

        public event WorkflowStateChangedEventHandler OnWorkflowStateChanged;

        public WorkFlowEngine()
        {
            //TODO:use DI
            _workflowTemplateRepository = new WorkflowTemplateRepository();    
        }

        public IWorkflowSession Current
        {
            get { return _sessionProvider.Current; }
        }

        public void RegisterSessionProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public void Initialize()
        {
            
        }

        public IEnumerable<IWorkflowTemplate> AvailableWorkflowTemplates
        {
            get
            {
                return new List<IWorkflowTemplate>();
            }
        }

        public IWorkflowTemplate LoadWorkflowTemplate(string workflowTemplateId)
        {
            return _workflowTemplateRepository.Find(workflowTemplateId);
        }
    }
}