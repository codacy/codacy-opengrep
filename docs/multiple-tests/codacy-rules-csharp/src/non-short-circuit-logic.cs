namespace Tests.Bugs
{
    class Logic
    {
        void M(string s, int flags)
        {
            if (GetTrue() | GetFalse()) { } // Noncompliant
            bool b = s != null & s.Length > 0; // Noncompliant
            var masked = flags & 4;
            if ((flags & 4) != 0) { }
            if (GetTrue() || GetFalse()) { }
        }

        bool GetTrue() { return true; }
        bool GetFalse() { return false; }
    }
}
