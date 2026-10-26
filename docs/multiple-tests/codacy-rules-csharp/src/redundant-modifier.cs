namespace Tests.Style
{
    public class MyClass
    {
        public virtual void Method()
        {
        }
    }

    public sealed class MyOtherClass : MyClass
    {
        public sealed override void Method() // Noncompliant
        {
            int x = 1;
            checked // Noncompliant
            {
                Use(x);
            }
            unchecked
            {
                x = x + 1;
            }
        }

        void Use(int x) { }
    }
}
