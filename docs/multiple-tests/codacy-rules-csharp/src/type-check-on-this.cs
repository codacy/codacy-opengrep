namespace Tests.Practices
{
    public class Food
    {
        public void DoSomething()
        {
            if (this is Pizza) // Noncompliant
            {
                Bake();
            }
        }

        void Bake() { }
    }

    public class Pizza : Food { }
}
