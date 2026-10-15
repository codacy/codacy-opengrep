using System;
using System.IO;

namespace Tests.Security
{
    class Catches
    {
        string M(string fileName)
        {
            string text = "";
            try
            {
                text = File.ReadAllText(fileName);
            }
            catch (Exception exc) // Noncompliant
            {
            }

            try
            {
                text = File.ReadAllText(fileName);
            }
            catch (Exception exc)
            {
                // the file is optional
            }
            return text;
        }
    }
}
