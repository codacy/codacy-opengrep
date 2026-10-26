namespace Tests.Bugs
{
    public class Parent
    {
        public Parent()
        {
            DoSomething();  // Noncompliant
            Helper();
        }

        public virtual void DoSomething() { }
        private void Helper() { }
    }

    public abstract class Shape
    {
        protected Shape(int size) : base()
        {
            this.Draw(); // Noncompliant
        }

        protected abstract void Draw();
    }

    public sealed class Closed
    {
        public Closed()
        {
            Helper();
        }

        private void Helper() { }
    }
}
