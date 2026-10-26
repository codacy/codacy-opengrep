namespace Tests.Bugs
{
    public class MyClass // Noncompliant
    {
        private MyClass() { }
        public int Value { get; set; }
    }

    public class Singleton
    {
        private Singleton() { }
        public static Singleton Instance { get; } = new Singleton();
    }

    public class Factory
    {
        private Factory() { }
        public static Factory Create() => new Factory();
    }

    public class Normal
    {
        public Normal() { }
    }
}
