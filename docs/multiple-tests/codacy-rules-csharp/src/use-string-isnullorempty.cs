namespace Tests.Performance
{
    class Strings
    {
        void M(string name)
        {
            if ("".Equals(name)) { } // Noncompliant
            if (!name.Equals("")) { } // Noncompliant
            if (name.Length == 0) { } // Noncompliant
            if (string.IsNullOrEmpty(name)) { }
        }
    }
}
