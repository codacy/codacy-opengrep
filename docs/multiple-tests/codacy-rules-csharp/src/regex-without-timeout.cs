using System;
using System.Text.RegularExpressions;

namespace Tests.Security
{
    class Regexes
    {
        public void RegexPattern(string input)
        {
            var emailPattern = new Regex(".+@.+", RegexOptions.None); // Noncompliant
            var isNumber = Regex.IsMatch(input, "[0-9]+"); // Noncompliant
            var withTimeout = new Regex(".+@.+", RegexOptions.None, TimeSpan.FromMilliseconds(100));
            var nonBacktracking = new Regex(".+@.+", RegexOptions.NonBacktracking);
        }
    }
}
