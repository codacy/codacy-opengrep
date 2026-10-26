namespace Tests.Bugs
{
    class MyClass
    {
        private static int count = 0;
        private static string name;

        public void DoSomething()
        {
            count++;  // Noncompliant
            name = "x"; // Noncompliant
        }

        public static void Reset()
        {
            count = 0;
        }
    }
}
