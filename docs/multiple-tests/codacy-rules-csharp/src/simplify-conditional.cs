namespace Tests.Style
{
    public class Conditions
    {
        void M(object a, object b, bool condition)
        {
            object x;
            if (a != null) // Noncompliant
            {
                x = a;
            }
            else
            {
                x = b;
            }

            x = a != null ? a : b; // Noncompliant
            x = (a == null) ? new object() : a; // Noncompliant

            if (condition) // Noncompliant
            {
                x = a;
            }
            else
            {
                x = b;
            }

            if (a == null)  // Noncompliant
                a = new object();

            a = a ?? new object(); // Noncompliant

            if (a == null)
            {
                a = new object();
            }
            else
            {
                Use(a);
            }

            x = a ?? b;
            x = condition ? a : b;
        }

        void Use(object o) { }
    }
}
