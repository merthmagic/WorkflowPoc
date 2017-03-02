using System;
using System.Collections.Generic;
using MedWorkflow.Exceptions;
using MedWorkflow.Repository;

namespace MedWorkflow
{
    /// <summary>
    /// 默认工作流引擎
    /// </summary>
    internal class WorkFlowEngine : IWorkflowEngine
    {
        private IUserCredentialsProvider _userCredentialsProvider;

        private readonly WorkflowTemplateRepository _workflowTemplateRepository;

        public event WorkflowStateChangedEventHandler OnWorkflowStateChanged;

        public WorkFlowEngine()
        {
            //TODO:Use dependency injection to loose couple
            _workflowTemplateRepository = new WorkflowTemplateRepository();
        }

        public IWorkflowSession WorkflowSession
        {
            get
            {
                var session = new DefaultWorkflowSession();
                return session;
            }
        }

        public void RegisterUserCredentialsProvider(IUserCredentialsProvider userCredentialsProvider)
        {
            _userCredentialsProvider = userCredentialsProvider;
        }

        public void Initialize()
        {

        }

        public IEnumerable<IWorkflowTemplate> AvailableWorkflowTemplates
        {
            get { return _workflowTemplateRepository.AvailableWorkflowTemplates; }
        }

        public IWorkflowTemplate LoadWorkflowTemplate(string workflowTemplateId)
        {
            return _workflowTemplateRepository.Find(workflowTemplateId);
        }


        public IUserCredentialsProvider RegisteredUserCredentialsProviderProvider
        {
            get
            {
                if (_userCredentialsProvider == null)
                    throw new IllegalStateException("未注册Session Provider");
                return _userCredentialsProvider;
            }
        }
    }
}