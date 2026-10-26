using System.Collections.Generic;

namespace Tests.Bugs
{
    class Overwrite
    {
        void M(List<string> list, Dictionary<string, string> dictionary, int index, string key)
        {
            list[index] = "value 1";
            list[index] = "value 2";  // Noncompliant

            dictionary.Add(key, "value 1");
            dictionary[key] = "value 2"; // Noncompliant

            list[index] = "a";
            list[index + 1] = "b";
        }
    }
}
