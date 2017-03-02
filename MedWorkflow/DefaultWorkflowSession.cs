using System.Collections.Generic;
using MedWorkflow.Factories;
using MedWorkflow.Security;

namespace MedWorkflow
{
    internal class DefaultWorkflowSession : AbstractWorkflowSession
    {
        public DefaultWorkflowSession()
        {
            
        }

        public override IApprover CurrentUser
        {
            get
            {
                //TODO:这里是不合理设计，Roles初始化应该由Approver类完成
                var approver = new Approver
                {
                    ApproverId = "admin123",
                    Roles = new List<IApproverRole>()
                };
                approver.Roles.AddRange(new List<ApproverRole>()
                {
                    new ApproverRole(){Id = "1",Name = "admin"}
                });
                return approver;
            }
        }

        public override void SaveInstance(IWorkflowInstance instance)
        {
            throw new System.NotImplementedException();
        }

        public override IWorkflowInstance LoadWorkflowInstance(string workflowInstanceId)
        {
            throw new System.NotImplementedException();
        }

        public override IWorkflowInstance NeWorkflowInstance(IWorkflowTemplate template, string formType, string formId)
        {
            var instance = WorkflowInstanceFactory.Create(template, new Form(formType, formId), CurrentUser,
                new WorkflowExecutionContext() { Approver = CurrentUser });
            return instance;
        }

        public override IEnumerable<IWorkflowInstance> TodoList
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}