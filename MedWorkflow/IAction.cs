namespace MedWorkflow
{
    public interface IAction
    {
        /// <summary>
        /// 操作码
        /// </summary>
        OperationCode OperationCode { get; }

        /// <summary>
        /// 目标Activity
        /// </summary>
        IActivityTemplate Transit { get; }
    }
}