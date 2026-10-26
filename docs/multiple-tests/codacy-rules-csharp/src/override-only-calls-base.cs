namespace Tests.Style
{
    public class Base
    {
        public virtual void Method() { }
        public virtual int Compute(int x) { return x; }
        public virtual string Describe() { return "base"; }
    }

    public class Derived : Base
    {
        public override void Method() // Noncompliant
        {
            base.Method();
        }

        public override int Compute(int x) // Noncompliant
        {
            return base.Compute(x);
        }

        public override string Describe()
        {
            return base.Describe() + "!";
        }
    }
}
