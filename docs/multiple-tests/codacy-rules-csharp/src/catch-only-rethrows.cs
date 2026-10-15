using System;
using System.IO;

namespace Tests.Practices
{
    class Rethrow
    {
        string M(string fileName)
        {
            string s = "";
            try
            {
                s = File.ReadAllText(fileName);
            }
            catch (Exception e)  // Noncompliant
            {
                throw;
            }

            try
            {
                s = File.ReadAllText(fileName);
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return s;
        }
    }
}
