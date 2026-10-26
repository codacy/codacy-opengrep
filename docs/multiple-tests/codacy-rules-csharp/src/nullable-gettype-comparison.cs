using System;

namespace Tests.Bugs
{
    class Nullables
    {
        void DoChecks<T>(Nullable<T> value) where T : struct
        {
            bool areEqual = value.GetType() == typeof(Nullable<int>); // Noncompliant
            bool other = value.GetType() != typeof(int?); // Noncompliant
            bool fine = value.GetType() == typeof(int);
        }
    }
}
