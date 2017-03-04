using System.Collections.Generic;
using System.Linq;
using MedWorkflow.ValueObjects;

namespace MedWorkflow
{
    public class ContractAppralFacade
    {
        /// <summary>
        /// 新建合同会签草稿
        /// </summary>
        /// <param name="form"></param>
        public static void NewContractDraft(ApprovableForm form)
        {
            var session = EngineContext.Current.NewSession();
            var template = EngineContext.Current.LoadWorkflowTemplate("WFT123456");
            var instance = session.NewWorkflowInstance(template, form.FormType.ToString(), form.FormId);
            session.SaveInstance(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId"></param>
        public static void Submit(string formId)
        {
            var session = EngineContext.Current.NewSession();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="deparments"></param>
        public static void AssignDepartments(string formId, IList<string> deparments)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="workerId"></param>
        public static void AssignWorker(string formId, string workerId)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="comment"></param>
        public static void Reject(string formId, string comment)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="comment"></param>
        public static void Approve(string formId, string comment)
        {
            
        }
    }
}