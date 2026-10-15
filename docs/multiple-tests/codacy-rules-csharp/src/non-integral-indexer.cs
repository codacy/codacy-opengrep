namespace Tests.Practices
{
    public class MyCustomClass { }

    public class Indexers
    {
        public int this[MyCustomClass index]  // Noncompliant
        {
            get { return 0; }
        }

        public int this[string key]
        {
            get { return 0; }
        }
    }
}
