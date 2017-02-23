using System.Collections;
using System.Collections.Generic;

namespace MedWorkflow
{
    public interface IWorkflowTemplate
    {
        /// <summary>
        /// 流程模板唯一标识
        /// </summary>
        string TemplateUuid { get; }

        /// <summary>
        /// 流程模板状态
        /// </summary>
        int Status { get; }

        /// <summary>
        /// 流程中的节点集合
        /// </summary>
        IEnumerable<IActivityTemplate> Activities { get; }
 

    }
}