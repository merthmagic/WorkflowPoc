using MedWorkflow.Events;

namespace MedWorkflow
{
    /// <summary>
    /// 流程状态更新处理委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void WorkflowStateChangedEventHandler(object sender, WorkflowStateChangedEvent args);
}