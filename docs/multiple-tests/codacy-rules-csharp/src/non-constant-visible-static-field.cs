namespace Tests.Practices
{
    public class Math
    {
        public static double Pi = 3.14;  // Noncompliant
        public const double E = 2.71;
        public static readonly double Tau = 6.28;
        private static int counter;
    }

    public class Shape
    {
        public static Shape Empty = new EmptyShape();  // Noncompliant

        private class EmptyShape : Shape
        {
        }
    }
}
