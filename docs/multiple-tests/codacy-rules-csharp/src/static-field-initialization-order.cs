namespace Tests.Bugs
{
    class MyClass
    {
        public static int X = Y; // Noncompliant
        public static int Y = 42;

        public static int A = 1;
        public static int B = A + 1;

        public static int C = D;
        public const int D = 3;
    }
}
