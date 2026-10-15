using System;

namespace Tests.Exceptions
{
    public class Thrower
    {
        public void DoSomething(object obj, string s)
        {
            if (obj == null)
            {
                throw new NullReferenceException("obj"); // Noncompliant
            }
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (s.Length == 0)
            {
                throw new Exception("empty"); // Noncompliant
            }
            if (s.Length == 1)
            {
                throw new System.ApplicationException(); // Noncompliant
            }
            var x = obj ?? throw new SystemException(); // Noncompliant
            throw new InvalidOperationException("ok");
        }
    }
}
