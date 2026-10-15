namespace Tests.Style
{
    class Strings
    {
        void M()
        {
            string tabInside = "A	B";                 // Noncompliant
            string escaped = "A\tB";
            string verbatim = @"A	B";
        }
    }
}
