using System;
using System.Runtime.Serialization;

namespace MedWorkflow.Exceptions
{
    /// <summary>
    /// 审批操作中出现非正常状态时抛出此异常
    /// </summary>
    [Serializable]
    public class IllegalStateException : ApplicationException
    {
        public IllegalStateException()
        {

        }

        public IllegalStateException(string message)
            : base(message)
        {

        }

        public IllegalStateException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {

        }

        protected IllegalStateException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }

        public IllegalStateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}