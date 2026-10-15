using System;

namespace Tests.Practices
{
    public class MyException : Exception // Noncompliant
    {
        public MyException()
        {
        }
    }

    public class CompleteException : Exception
    {
        public CompleteException()
        {
        }

        public CompleteException(string message)
            : base(message)
        {
        }

        public CompleteException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
