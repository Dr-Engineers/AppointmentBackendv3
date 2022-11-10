using System;
using System.Runtime.Serialization;

namespace Appointmentv3.BL
{
    [Serializable]
    internal class CannotBookAppointment : ApplicationException
    {
        public CannotBookAppointment()
        {
        }

        public CannotBookAppointment(string message) : base(message)
        {
        }

        public CannotBookAppointment(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotBookAppointment(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}