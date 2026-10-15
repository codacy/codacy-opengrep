using System;

namespace Tests.Bugs
{
    class Todo
    {
        void DoTheThing()
        {
            throw new NotImplementedException(); // Noncompliant
        }

        int Other() => throw new NotImplementedException(); // Noncompliant

        void Fine()
        {
            throw new NotSupportedException();
        }
    }
}
