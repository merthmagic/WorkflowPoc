namespace MedWorkflow
{
    /// <summary>
    /// 抽象表单
    /// </summary>
    public interface IForm
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        string FormType { get; }

        /// <summary>
        /// 表单唯一标识
        /// </summary>
        string FormId { get; }
    }
}