namespace MedWorkflow
{
    public class EngineContext
    {
        private static IWorkflowEngine _workflowEngine;

        private static volatile object _mutex = new object();

        public static IWorkflowEngine Current
        {
            get
            {
                if (_workflowEngine == null)
                {
                    lock (_mutex)
                    {
                        if(_workflowEngine == null)
                            _workflowEngine = new WorkFlowEngine();
                    }
                }
                return _workflowEngine;
            }
        } 
    }
}