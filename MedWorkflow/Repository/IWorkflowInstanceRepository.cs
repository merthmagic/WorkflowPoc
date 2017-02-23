using System;

namespace MedWorkflow.Repository
{
    public interface IWorkflowInstanceRepository
    {
        IWorkflowInstance Find(string workflowInstanceId);


        void Save(IWorkflowInstance workflowInstance);
    }
}