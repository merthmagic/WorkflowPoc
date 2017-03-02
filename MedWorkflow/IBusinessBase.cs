using System;

namespace MedWorkflow
{
    public interface IBusinessBase
    {
        bool IsNew { get; }

        bool IsDirty { get; }

        bool IsTransient { get; }
    }
}