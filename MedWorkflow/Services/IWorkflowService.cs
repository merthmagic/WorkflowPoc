using System.Collections.Generic;

namespace MedWorkflow.Services
{
    public interface IWorkflowService
    {
        IEnumerable<IWorkflowTemplate> GetTemplates();

        void NewWorkflowInstance(IWorkflowTemplate template);
    }
}
