using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EyeRestTimer
{
    public class InvalidAlarmFile : Exception
    {
        public InvalidAlarmFile()
        {
        }

        public InvalidAlarmFile(string message) : base(message)
        {
        }

        public InvalidAlarmFile(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAlarmFile(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
