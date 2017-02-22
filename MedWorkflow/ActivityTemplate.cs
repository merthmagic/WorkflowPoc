using System.Collections.Generic;

namespace MedWorkflow
{
    internal class ActivityTemplate : IActivityTemplate
    {
        private readonly IWorkflowTemplate _workflowTemplate;

        public ActivityTemplate(IWorkflowTemplate workflowTemplate)
        {
            _workflowTemplate = workflowTemplate;
        }

        private IEnumerable<IAction> _allowedActions;

        public bool BeginActivity { get; set; }

        public bool FinalActivity { get; set; }

        public IApprovalPolicy ApprovalPolicy { get; set; }

        public IEnumerable<IAction> AllowedActions
        {
            get { return _allowedActions ?? (_allowedActions = new List<IAction>()); }
        }

        public IWorkflowTemplate WorkflowTemplate
        {
            get { return _workflowTemplate; }
        }
    }
}