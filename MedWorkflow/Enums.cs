namespace MedWorkflow
{
    public enum ActivityInstanceStatus
    {
        Working = 10,
        Finished = 20
    }

    public enum WorkflowInstanceStatus
    {
        New = 1,
        Active = 2,
        Finished = 4,
        Archive = 8
    }
}