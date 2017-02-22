using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedWorkflow
{
    public interface IWorkflowService
    {
        IEnumerable<IWorkflowTemplate> GetTemplates();

        void NewWorkflowInstance(IWorkflowTemplate template);
    }
}
