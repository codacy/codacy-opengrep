using System;

namespace Tests.Bugs
{
    class Rethrow
    {
        void M()
        {
            try
            {
                Work();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw exception; // Noncompliant
            }
        }

        void N()
        {
            try
            {
                Work();
            }
            catch (Exception exception)
            {
                throw new Exception("Additional information", exception);
            }
        }

        void Work() { }
    }
}
