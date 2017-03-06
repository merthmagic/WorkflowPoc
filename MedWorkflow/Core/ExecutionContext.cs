using System.Collections.Generic;
using MedWorkflow.Security;

namespace MedWorkflow.Core
{
    public class ExecutionContext
    {
        private readonly IApprover _approver;
        private IDictionary<string, object> _variables;
        private readonly IWorkflowInstance _workflowInstance;

        public ExecutionContext(IApprover approver,IWorkflowInstance workflowInstance)
        {
            _approver = approver;
            _workflowInstance = workflowInstance;
        }

        public IApprover Approver { get { return _approver; } }

        public IDictionary<string, object> Variables
        {
            get { return _variables ?? (_variables = new Dictionary<string, object>()); }
        }

        public IWorkflowInstance WorkflowInstance
        {
            get { return _workflowInstance; }
        }
    }
}