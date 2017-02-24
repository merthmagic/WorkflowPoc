using MedWorkflow.Security;

namespace MedWorkflow
{
    public class PhantomSessionProvider:ISessionProvider
    {

        public IWorkflowSession Current
        {
            get { return new PhantomWorkflowSession(); }
        }
    }
}