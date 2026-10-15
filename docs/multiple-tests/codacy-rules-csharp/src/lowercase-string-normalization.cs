namespace Tests.Practices
{
    class Normalization
    {
        bool M(string a)
        {
            var areEqual = "INTEGER".ToLower() == "integer"; // Noncompliant
            var other = a.ToLowerInvariant() == "x"; // Noncompliant
            return a.ToUpperInvariant() == "INTEGER";
        }
    }
}
