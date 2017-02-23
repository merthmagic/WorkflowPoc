namespace MedWorkflow
{
    public interface IPolicy
    {
        bool CanMoveNext(IActivityInstance activityInstance);
    }
}