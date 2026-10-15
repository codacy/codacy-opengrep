using System;

namespace Tests.Performance
{
    [AttributeUsage(AttributeTargets.All)]
    public class MyAttribute : Attribute // Noncompliant
    {
        public string Name { get; }

        public MyAttribute(string name) => Name = name;
    }

    [AttributeUsage(AttributeTargets.All)]
    public sealed class SealedAttribute : Attribute
    {
    }

    public abstract class BaseAttribute : Attribute
    {
    }
}
