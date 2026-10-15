namespace Tests.Unused
{
    public class MoreMath<T>   // Noncompliant
    {
        public int Add<U>(int a, int b) // Noncompliant
        {
            return a + b;
        }

        public void Use<V>(V value)
        {
            System.Console.WriteLine(value);
        }
    }

    public class Box<T>
    {
        public T Value { get; set; }
    }
}
