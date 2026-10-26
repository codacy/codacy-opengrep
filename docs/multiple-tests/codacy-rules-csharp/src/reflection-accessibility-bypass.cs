using System;
using System.Reflection;

namespace Tests.Practices
{
    class Reflection
    {
        void M()
        {
            Type dynClass = Type.GetType("MyInternalClass");
            BindingFlags bindingAttr = BindingFlags.NonPublic | BindingFlags.Static; // Noncompliant
            MethodInfo dynMethod = dynClass.GetMethod("mymethod", bindingAttr);
            var pub = dynClass.GetMethod("Public", BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
