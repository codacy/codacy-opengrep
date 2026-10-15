using System;

namespace Tests.Practices
{
    public sealed class MyAttribute : Attribute // Noncompliant
    {
        private string text;

        public MyAttribute(string text)
        {
            this.text = text;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class GoodAttribute : Attribute
    {
    }
}
