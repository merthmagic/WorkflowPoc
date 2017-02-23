using System;
using System.Collections.Generic;
using MedWorkflow.Audit;
using MedWorkflow.Security;

namespace MedWorkflow
{
    internal class WorkflowInstance : IWorkflowInstance
    {
        private readonly IWorkflowTemplate _workflowTemplate;
        private readonly IForm _form;
        private readonly IApprover _owner;
        private ICollection<AuditTrailEntry> _auditTrailEntries;

        public WorkflowInstance(IWorkflowTemplate workflowTemplate, IForm form, IApprover owner)
        {
            _workflowTemplate = workflowTemplate;
            _form = form;
            _owner = owner;
        }

        public IWorkflowTemplate WorkflowTemplate
        {
            get { return _workflowTemplate; }
        }

        public IForm Form
        {
            get { return _form; }
        }

        public Security.IApprover Owner
        {
            get { return _owner; }
        }

        public ICollection<AuditTrailEntry> AuditTrails
        {
            get { return _auditTrailEntries ?? (_auditTrailEntries = new List<AuditTrailEntry>()); }
        }

        public DateTime ExpireOn
        {
            get { throw new NotSupportedException(); }
        }
    }
}