using System;

namespace Tests.Bugs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Environment.Exit(1);
            }
        }

        public void Stop()
        {
            Environment.Exit(0); // Noncompliant
        }
    }
}
