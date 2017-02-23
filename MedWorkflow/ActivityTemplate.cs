using System.Collections.Generic;

namespace MedWorkflow
{
    internal class ActivityTemplate : IActivityTemplate
    {
        private IList<Action> _allowedActions;

        public bool BeginActivity { get; set; }

        public bool FinalActivity { get; set; }

        public IApprovalPolicy ApprovalPolicy { get; set; }

        public IEnumerable<IAction> AllowedActions
        {
            get { return Actions; }
        }

        public IList<Action> Actions
        {
            get { return _allowedActions ?? (_allowedActions = new List<Action>()); }
        }
 
        public string Name { get;  set; }

        public int ActivityTemplateId { get;  set; }

        public IWorkflowTemplate WorkflowTemplate { get; set; }


        public Security.IApproverRole RequiredRole { get; set; }
    }
}