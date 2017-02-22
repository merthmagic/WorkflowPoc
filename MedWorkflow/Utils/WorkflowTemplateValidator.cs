using System;
using System.Linq;
using MedWorkflow.Exceptions;

namespace MedWorkflow.Utils
{
    public sealed class WorkflowTemplateValidator
    {
        /// <summary>
        /// 验证流程模板
        /// </summary>
        /// <param name="workflowTemplate"></param>
        /// <returns></returns>
        public static void Validate(IWorkflowTemplate workflowTemplate)
        {
            //判断首尾节点唯一
            if (workflowTemplate.Activities.Count(p => p.BeginActivity) > 1 
                || workflowTemplate.Activities.Count(q => q.FinalActivity) > 1)
                throw new IllegalWorkflowTemplateException();

            //TODO:确保无孤立节点

        }
    }
}