namespace Tests.Performance
{
    class Checks
    {
        public int MyProperty { get; set; }

        void M(int a)
        {
            int x = 0;
            if (x != a) // Noncompliant
            {
                x = a;
            }
            if (MyProperty != a)
            {
                MyProperty = a;
            }
            System.Console.WriteLine(x);
        }
    }
}
