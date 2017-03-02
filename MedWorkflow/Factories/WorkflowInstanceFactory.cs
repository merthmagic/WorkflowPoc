using System;
using System.Collections.Generic;
using System.Linq;
using MedWorkflow.Security;

namespace MedWorkflow.Factories
{
    internal class WorkflowInstanceFactory
    {
        /// <summary>
        /// 创建工作流实例的工厂方法
        /// </summary>
        /// <param name="template"></param>
        /// <param name="form"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IWorkflowInstance Create(IWorkflowTemplate template, IForm form, WorkflowExecutionContext context)
        {
            var instance =  new WorkflowInstance(template, form, context);
            return instance;
        }

        /// <summary>
        /// 创建工作流实例的工厂方法(新流程)
        /// </summary>
        /// <param name="template"></param>
        /// <param name="form"></param>
        /// <param name="owner"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IWorkflowInstance Create(IWorkflowTemplate template, IForm form, IApprover owner, WorkflowExecutionContext context)
        {
            //新建第一个activity实例，流程owner进行提交
            var instance = new WorkflowInstance(template, form, owner, context);
            var activityInstance = new ActivityInstance
            {
                ActivityTemplate = template.Activities.First(),
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now
            };
            instance.Current = activityInstance;
            return instance;
        }
    }
}