namespace Tests.Practices
{
    abstract class Base
    {
        public Base() // Noncompliant
        {
        }

        public void Work()
        {
        }
    }

    abstract class Fine
    {
        protected Fine()
        {
        }
    }
}
