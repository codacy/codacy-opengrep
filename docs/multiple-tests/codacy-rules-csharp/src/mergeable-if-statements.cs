namespace Tests.Style
{
    public class Ifs
    {
        void M(object file, bool a, bool b)
        {
            if (file != null) // Noncompliant
            {
                if (a || b)
                {
                    Do();
                }
            }

            if (file != null && (a || b))
            {
                Do();
            }

            if (a)
            {
                if (b) { Do(); }
            }
            else
            {
                Do();
            }

            if (a)
            {
                if (b) { Do(); } else { Do(); }
            }

            if (a)
            {
                Do();
                if (b) { Do(); }
            }
        }

        void Do() { }
    }
}
