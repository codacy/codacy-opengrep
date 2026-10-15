using System;
using System.Globalization;

namespace Tests.Performance
{
    class Strings
    {
        string Interpolate(string value) =>
            FormattableString.Invariant($"Value: {value}"); // Noncompliant

        string Interpolate2(string value) =>
            FormattableString.CurrentCulture($"Value: {value}"); // Noncompliant

        string Good(string value) =>
            string.Create(CultureInfo.InvariantCulture, $"Value: {value}");
    }
}
