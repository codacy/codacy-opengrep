namespace Tests.Complexity
{
    public class BaseClass
    {
        public BaseClass(int p1) { }
    }

    public class Params : BaseClass
    {
        public Params(int a, int b, int c, int d, int e, int f, int g, int h) : base(a) { }
        public Params(int a, int b, int c, int d, int e, int f, int g, int h, int i) : base(a) { }
        void SetCoordinates(int x1, int y1, int z1, int x2, int y2, int z2) { }
        void Seven(int a, int b, int c, int d, int e, int f, int g) { }
        void Eight(int a, int b, int c, int d, int e, int f, int g, int h) { } // Noncompliant
        int Arrow(int a, int b, int c, int d, int e, int f, int g, int h) => a; // Noncompliant
    }

    public class Plain
    {
        public Plain(int a, int b, int c, int d, int e, int f, int g, int h) { } // Noncompliant
    }

    public interface IWide
    {
        void Wide(int a, int b, int c, int d, int e, int f, int g, int h); // Noncompliant
    }
}
