namespace Tests.Performance
{
    class Concat
    {
        string Join(string[] arrayOfStrings)
        {
            string str = "";
            for (int i = 0; i < arrayOfStrings.Length; ++i)
            {
                str = str + arrayOfStrings[i]; // Noncompliant
            }
            foreach (var s in arrayOfStrings)
            {
                str += s; // Noncompliant
            }
            int total = 0;
            foreach (var s in arrayOfStrings)
            {
                total += s.Length;
            }
            return str + total;
        }
    }
}
