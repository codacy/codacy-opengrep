using System;
using System.Reflection;

namespace Tests.Performance
{
    public class Example
    {
        public static void Main()
        {
            Assembly assem = Assembly.GetExecutingAssembly(); // Noncompliant
            Assembly better = typeof(Example).Assembly;
            Console.WriteLine(assem.FullName + better.FullName);
        }
    }
}
