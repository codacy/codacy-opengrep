namespace Tests.Style
{
    class Params
    {
        void Method(params string[] values)
        {
        }

        void Caller()
        {
            Method(new string[] { "s1", "s2" }); // Noncompliant
            Method("s1", "s2");
        }
    }
}
