using System;
using System.Collections.Generic;

namespace MedWorkflow
{
    /// <summary>
    /// 默认工作流引擎
    /// </summary>
    internal class WorkFlowEngine:IWorkflowEngine
    {
        private ISessionProvider _sessionProvider;

        public event WorkflowStateChangedEventHandler OnWorkflowStateChanged;

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
            //TODO:
        }

        public System.Collections.Generic.IEnumerable<IWorkflowTemplate> AvailableWorkflowTemplates
        {
            get
            {
                return new List<IWorkflowTemplate>();
            }
        }
    }
}