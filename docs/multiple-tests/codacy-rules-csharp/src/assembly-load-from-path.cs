using System.Reflection;

namespace Tests.Bugs
{
    class Loader
    {
        static void Main(string[] args)
        {
            Assembly.LoadFrom("somepath.dll"); // Noncompliant
            Assembly.LoadFile("somepath.dll"); // Noncompliant
            Assembly.LoadWithPartialName("Something"); // Noncompliant
            Assembly.Load("Something, Version=1.0.0.0");
        }
    }
}
