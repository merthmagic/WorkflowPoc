using System;
using MedWorkflow.Security;

namespace MedWorkflow.Factories
{
    public class WorkflowInstanceFactory
    {
        /// <summary>
        /// 创建工作流实例的工厂方法
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static IWorkflowInstance Create(IWorkflowTemplate template,IForm form,IApprover owner)
        {
            return new WorkflowInstance(template,form,owner);
        }
    }
}