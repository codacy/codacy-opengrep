using System;
using System.Reflection;

[assembly: AssemblyProduct("Library")] // Noncompliant
[assembly: CLSCompliant(true)]

namespace MyLibrary
{
    public class Holder2 { }
}
