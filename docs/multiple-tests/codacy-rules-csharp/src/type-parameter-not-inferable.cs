namespace Tests.Practices
{
    public class Generics
    {
        public void MyMethod<T>()  // Noncompliant
        {
        }

        public void Inferred<T>(T value)
        {
        }

        void Caller()
        {
            MyMethod<int>();
        }
    }
}
