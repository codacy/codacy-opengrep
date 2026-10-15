using System;

namespace Tests.Bugs
{
    class Types
    {
        void ExamineSystemType(string str)
        {
            Type stringType = str.GetType();
            Type runtimeType = stringType.GetType(); // Noncompliant
            var t2 = typeof(string).GetType(); // Noncompliant
            var t3 = typeof(Type).GetType();
            if (stringType.IsInstanceOfType(typeof(string))) // Noncompliant
            {
            }
        }
    }
}
