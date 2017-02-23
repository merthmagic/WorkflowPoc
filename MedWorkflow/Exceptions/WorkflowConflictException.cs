using System;
using System.Runtime.Serialization;

namespace MedWorkflow.Exceptions
{
    [Serializable]
    public class WorkflowConflictException : ApplicationException
    {
        public WorkflowConflictException()
        {

        }

        public WorkflowConflictException(string message)
            : base(message)
        {

        }

        public WorkflowConflictException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {

        }

        protected WorkflowConflictException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }

        public WorkflowConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}