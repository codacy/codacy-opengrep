using System.Text.RegularExpressions;

namespace Tests.Bugs
{
    class Regexes
    {
        void M(string input)
        {
            var regex = new Regex("[A"); // Noncompliant
            var match = Regex.Match(input, "(abc"); // Noncompliant
            var stars = Regex.IsMatch(input, "*abc"); // Noncompliant
            var ok = new Regex("[A-Z]+(abc)?");
            var ok2 = Regex.IsMatch(input, @"\(literal\)");
        }
    }
}
