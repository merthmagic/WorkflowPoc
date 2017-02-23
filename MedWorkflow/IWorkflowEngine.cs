using System;
using System.Security.Cryptography.X509Certificates;

namespace MedWorkflow
{
    /// <summary>
    /// 工作流引擎
    /// </summary>
    public interface IWorkflowEngine
    {
        /// <summary>
        /// 流程状态更新事件
        /// </summary>
        event WorkflowStateChangedEventHandler OnWorkflowStateChanged;
    }
}