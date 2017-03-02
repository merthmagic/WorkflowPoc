using System.Linq;
using MedWorkflow.Exceptions;

namespace MedWorkflow.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            NewInstanceAndSubmit();
        }

        static void NewInstanceAndSubmit()
        {
            var workflowEngine = EngineContext.Current;

            //注册一个模拟的Session Provider进行测试
            var sessionProvider = new PhantomUserCredentialsProvider();
            workflowEngine.RegisterUserCredentialsProvider(sessionProvider);

            //注册事件处理方法如流程状态变化邮件通知等
            workflowEngine.OnWorkflowStateChanged += (sender, args) =>
            {
                //TODO:
            };

            //获取会话，通过会话进行流程相关操作
            var session = workflowEngine.NewSession();

            var template = workflowEngine.LoadWorkflowTemplate("WFT123456");

            var instance = session.NewWorkflowInstance(template, "Contract", "123456");

            instance.Submit("提交申请");
            session.SaveInstance(instance);

            instance.Approve("批准");
            session.SaveInstance(instance);
        }

        static void ApproveExistInstance()
        {
            var workflowEngine = EngineContext.Current;
            //注册一个模拟的Session Provider进行测试
            var sessionProvider = new PhantomUserCredentialsProvider();

            workflowEngine.RegisterUserCredentialsProvider(sessionProvider);

            var session = workflowEngine.NewSession();

            var instance =
                session.TodoList.FirstOrDefault(p => p.Form.FormType == "Contract" && p.Form.FormId == "123456");
            if (instance == null)
                throw new IllegalStateException("流程不存在");

            //查看流程当前的节点
            var activityInstance = instance.Current;
            //查看流程当前节点的模板定义信息
            var activityTemplate = activityInstance.ActivityTemplate;
            //当前允许做什么操作
            var actions = activityTemplate.AllowedActions;
            //如果要查看流程模板
            var workflowTemplate = activityTemplate.WorkflowTemplate;
        }
    }
}
