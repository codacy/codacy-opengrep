namespace Tests.Style
{
    public class Inversions
    {
        void M(int a, int i)
        {
            if (!(a == 2)) { } // Noncompliant
            bool b = !(i < 10); // Noncompliant
            bool c = a != 2;
            bool d = !Check(a);
        }

        bool Check(int a) { return a > 0; }
    }
}
