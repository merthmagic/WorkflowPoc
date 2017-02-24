using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MedWorkflow.Factories;
using MedWorkflow.Security;
using MedWorkflow.Utils;

namespace MedWorkflow.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlString = File.ReadAllText(@"D:\WorkflowTemplatePoc.xml", Encoding.UTF8);
            var template = XmlWorkflowTemplateParser.ParseFromString(xmlString);

            var role = new ApproverRole()
            {
                Id = "1",
                Name = "admin",
                Description = "Role with administration rights"
            };

            var approver = new Approver()
            {
                ApproverId = "1",
                Roles = new List<IApproverRole>() { role }
            };

            var context = new WorkflowExecutionContext() { Approver = approver };
            var workflow = WorkflowInstanceFactory.Create(template, null, approver, context);
            workflow.Submit("提交");
            workflow.Approve("批准");
            workflow.Reject("驳回");

            Console.ReadKey(true);
        }

        static void Run()
        {
            var workflowEngine = EngineContext.Current;
            //注册一个模拟的Session Provider进行测试
            var sessionProvider = new PhantomSessionProvider();

            workflowEngine.RegisterSessionProvider(sessionProvider);

            //注册事件处理方法
            workflowEngine.OnWorkflowStateChanged += (sender, args) =>
            {

            };

            var session = workflowEngine.Current;

            var template = workflowEngine.AvailableWorkflowTemplates
                .FirstOrDefault(p => p.TemplateUuid == "WFT123456");

            var instance = session.NeWorkflowInstance(template,"Contract","123456");

            instance.Submit("提交申请");
            session.SaveInstance(instance);

            instance.Approve("批准");
            session.SaveInstance(instance);

        }
    }
}
