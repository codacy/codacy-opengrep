using System;

namespace Tests.Practices
{
    internal class MyException : Exception   // Noncompliant
    {
    }

    public class PublicException : Exception
    {
    }

    class ImplicitInternalException : InvalidOperationException // Noncompliant
    {
    }
}
