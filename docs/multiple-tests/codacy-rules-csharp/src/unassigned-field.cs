namespace Tests.Practices
{
    class MyClass
    {
        private int field; // Noncompliant
        private int assigned;
        private string initialized = "x";

        public MyClass(int value)
        {
            assigned = value;
        }

        public int Sum() => field + assigned + initialized.Length;
    }
}
