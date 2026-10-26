namespace Tests.Bugs
{
    class Prefix
    {
        void M(int v1, bool v2)
        {
            var v3 = !!v2; // Noncompliant
            var v4 = ~~v1; // Noncompliant
            var v5 = !v2;
        }
    }
}
