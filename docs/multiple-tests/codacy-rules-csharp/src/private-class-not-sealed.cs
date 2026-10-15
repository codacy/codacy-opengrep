namespace Tests.Performance
{
    public class Outer
    {
        private class MyClass  // Noncompliant
        {
        }

        private class BaseClass
        {
        }

        private sealed class Derived : BaseClass
        {
        }

        private sealed class AlreadySealed
        {
        }
    }
}
