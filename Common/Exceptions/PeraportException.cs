using System;
using System.Threading;

namespace Common.Exceptions
{
    public class PeraportException : Exception
    {
        public PeraportException()
        {

        }

        public PeraportException(string message)
            : base(message)
        {

        }
        public PeraportException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
