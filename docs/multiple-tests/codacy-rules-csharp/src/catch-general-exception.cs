using System;
using System.IO;

namespace Tests.Bugs
{
    class Catches
    {
        void M()
        {
            try
            {
                File.ReadAllText("a");
            }
            catch (Exception e) // Noncompliant
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                File.ReadAllText("a");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                File.ReadAllText("a");
            }
            catch (Exception e) when (e is IOException)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                File.ReadAllText("a");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            try
            {
                File.ReadAllText("a");
            }
            catch // Noncompliant
            {
                Console.WriteLine("failed");
            }
        }
    }
}
