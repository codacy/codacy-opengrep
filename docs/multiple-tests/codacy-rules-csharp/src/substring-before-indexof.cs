namespace Tests.Performance
{
    class Substrings
    {
        void M(string str, int startIndex, char char1)
        {
            if (str.Substring(startIndex).IndexOf(char1) == -1) // Noncompliant
            {
            }
            if (str.IndexOf(char1, startIndex) == -1)
            {
            }
        }
    }
}
