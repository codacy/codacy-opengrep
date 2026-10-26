using System;

namespace Tests.Bugs
{
    class Finally
    {
        void M()
        {
            try
            {
                throw new ArgumentException();
            }
            finally
            {
                Cleanup();
                throw new InvalidOperationException(); // Noncompliant
            }
        }

        void N()
        {
            try
            {
                Cleanup();
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException();
            }
            finally
            {
                Cleanup();
            }
        }

        void Cleanup() { }
    }
}
