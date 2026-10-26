namespace Tests.Bugs
{
    class Base
    {
        public virtual void Method(int[] numbers)
        {
        }
    }

    class Derived : Base
    {
        public override void Method(params int[] numbers) // Noncompliant
        {
        }

        public void Other(params int[] numbers)
        {
        }
    }
}
