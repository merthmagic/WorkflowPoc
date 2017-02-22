using System.Collections.Generic;

namespace MedWorkflow.Security
{
    /// <summary>
    /// 审批人过滤器，通过条件过滤出当前流程在Activity所指定的审批人
    /// </summary>
    public interface IApproverFilter
    {
        List<IApprover> Filter(string filterName, params string[] parameters);
    }
}