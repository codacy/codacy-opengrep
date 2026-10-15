using System.Collections.Generic;

namespace Tests.Practices
{
    class Loops
    {
        List<string> M(List<string> collection)
        {
            var result = new List<string>();
            foreach (var element in collection)  // Noncompliant
            {
                if (element.Length > 3)
                {
                    result.Add(element);
                }
            }
            foreach (var element in collection)
            {
                result.Add(element);
                if (element.Length > 3)
                {
                    result.Add(element);
                }
            }
            return result;
        }
    }
}
