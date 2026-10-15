namespace Tests.Performance
{
    class Chars
    {
        bool StartsWithSlash(string s) =>
            s.StartsWith("/"); // Noncompliant

        bool EndsWithSlash(string s) =>
            s.EndsWith("/"); // Noncompliant

        bool StartsWithChar(string s) =>
            s.StartsWith('/');

        bool StartsWithPrefix(string s) =>
            s.StartsWith("//");
    }
}
