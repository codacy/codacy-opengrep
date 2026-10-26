namespace Tests.Practices
{
    public static class MyClass
    {
        public static void Print(int number) { }
        public static void Print(int number, string delimiter = "\n") { } // Noncompliant
        public static void Other(string s) { }
        public static void Other(int number, string delimiter = "\n") { }
    }
}
