namespace Tests.Bugs
{
    class Formats
    {
        void M(object arg0, object arg1, object arg2)
        {
            var s = string.Format("{0}", arg0, arg1); // Noncompliant
            s = string.Format("{0} {2}", arg0, arg1, arg2); // Noncompliant
            s = string.Format("no placeholders", arg0); // Noncompliant
            s = string.Format("{1} {0}", arg0, arg1);
            s = string.Format("{0}", arg0);
        }
    }
}
