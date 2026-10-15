namespace Tests.Practices
{
    public class Fruit
    {
        protected bool ripe;
        protected int flesh;
    }

    public class Raspberry : Fruit
    {
        private bool ripe; // Noncompliant
        private int color;
    }
}
