using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using MedWorkflow.Audit;
using MedWorkflow.Exceptions;
using MedWorkflow.Security;

namespace MedWorkflow
{
    /// <summary>
    /// <remarks>
    /// 禁用了空指针检查，内部已有方法进行Assert
    /// </remarks>
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal class WorkflowInstance : IWorkflowInstance
    {
        private readonly IWorkflowTemplate _workflowTemplate;
        private readonly IForm _form;
        private readonly IApprover _owner;
        private ICollection<AuditTrailEntry> _auditTrailEntries;
        private readonly IWorkflowExecutionContext _executionContext;
        private IActivityInstance _currentActivityInstance;
        private bool isDirty = true;

        public WorkflowInstance(IWorkflowTemplate workflowTemplate, IForm form, IApprover owner)
        {
            _workflowTemplate = workflowTemplate;
            _form = form;
            _owner = owner;
        }

        public WorkflowInstance(IWorkflowTemplate workflowTemplate, IWorkflowExecutionContext context)
        {
            _workflowTemplate = workflowTemplate;
            _executionContext = context;
        }


        public IWorkflowTemplate WorkflowTemplate
        {
            get { return _workflowTemplate; }
        }

        public IForm Form
        {
            get { return _form; }
        }

        public IApprover Owner
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

        /// <summary>
        /// 当前节点
        /// </summary>
        public IActivityInstance Current { get; private set; }

        public IWorkflowExecutionContext ExecutionContext
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDirty { get{return isDirty;} }

        public void MarkOld()
        {
            isDirty = false;
        }

        private void AssertOperation(IActivityInstance activityInstance, OperationCode operationCode)
        {
            if (activityInstance.ActivityTemplate.AllowedActions.All(p => p.OperationCode != operationCode))
                throw new InvalidOperationException("当前节点不允许此操作");
        }

        private void AssertPrivilege(IActivityInstance activityInstance)
        {
             if(!_executionContext.Approver.Roles.Contains(activityInstance.ActivityTemplate.RequiredRole))
                 throw new IllegalStateException();
        }

        private IActivityInstance NewActivityInstance(IActivityTemplate activityTemplate)
        {
            throw new NotImplementedException();    
        }

        #region Operations
        public void Submit(string comment)
        {
            AssertOperation(Current,OperationCode.Submit);
            AssertPrivilege(Current);
            var activityInstance =
                NewActivityInstance(
                    Current.ActivityTemplate.AllowedActions.FirstOrDefault(p => p.OperationCode == OperationCode.Submit)
                        .Transit);
            var auditTrail = new AuditTrailEntry(){IsNew = true};
            //添加审核日志
            AuditTrails.Add(auditTrail);
        }

        public void Approve(string comment)
        {
            AssertOperation(Current, OperationCode.Approve);
            AssertPrivilege(Current);
        }

        public void Cancel(string comment)
        {
            AssertOperation(Current, OperationCode.Cancel);
            AssertPrivilege(Current);
        }

        public void Reject(string comment)
        {
            AssertOperation(Current, OperationCode.Reject);
            AssertPrivilege(Current);
        }

        public void Assign(AssignSpecification assignSpecification)
        {
            AssertOperation(Current, OperationCode.Assign);
            AssertPrivilege(Current);
        }

        public void Delegate(AssignSpecification assignSpecification)
        {
            AssertOperation(Current, OperationCode.Delegate);
            AssertPrivilege(Current);
        }
        #endregion
    }
}