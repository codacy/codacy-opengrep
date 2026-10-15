namespace Tests.Practices
{
    public class Base
    {
        protected virtual void Hook() { }
    }

    public sealed class MySealedClass : Base
    {
        protected string name = "Fred";  // Noncompliant
        protected void SetName(string name) // Noncompliant
        {
            this.name = name;
        }

        protected override void Hook() { }
    }
}
