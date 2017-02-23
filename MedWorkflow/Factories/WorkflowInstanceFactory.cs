using System;
using MedWorkflow.Security;

namespace MedWorkflow.Factories
{
    public class WorkflowInstanceFactory
    {
        /// <summary>
        /// 创建工作流实例的工厂方法
        /// </summary>
        /// <param name="template">流程模板</param>
        /// <param name="form">表单</param>
        /// <param name="owner">创建人</param>
        /// <returns></returns>
        public static IWorkflowInstance Create(IWorkflowTemplate template,IForm form,IApprover owner)
        {
            return new WorkflowInstance(template,form,owner);
        }
    }
}