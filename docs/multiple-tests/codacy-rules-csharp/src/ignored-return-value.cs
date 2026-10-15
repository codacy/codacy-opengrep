using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Bugs
{
    class Returns
    {
        void M(List<int> data, string text, DateTime date)
        {
            data.Where(x => x > 5).Select(x => x * x); // Noncompliant
            "this string".Equals("other string"); // Noncompliant
            text.Trim(); // Noncompliant
            date.AddYears(1); // Noncompliant
            data.Add(1);
            var result = data.Where(x => x > 5).ToList();
            text = text.Trim();
            int.TryParse(text, out var n);
        }
    }
}
