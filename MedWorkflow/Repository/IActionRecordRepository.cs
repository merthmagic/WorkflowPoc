using System.Collections.Generic;

namespace MedWorkflow.Repository
{
    public interface IActionRecordRepository
    {
        IEnumerable<ActionRecord> Find(IActivityInstance activityInstance);
    }
}