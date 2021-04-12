using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter07
{
    class CarIsDeadException :ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException() { }
        public CarIsDeadException(string message, string cause, DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public override string Message
            => $"Car Error Message: {messageDetails}";
    }

    class CarIsDeadException2 : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException2() { }
        public CarIsDeadException2(string message, string cause, DateTime time)
            :base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }

    [Serializable]
    class CarIsDeadException3 : ApplicationException
    {
        public CarIsDeadException3() { }
        public CarIsDeadException3(string message)
            : base(message) { }
        public CarIsDeadException3(string message, System.Exception inner)
            :base(message, inner) { }
        protected CarIsDeadException3(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        
        public CarIsDeadException3(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
