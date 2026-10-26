namespace Tests.Bugs
{
    class Generics
    {
        bool IsDefault<T>(T value)
        {
            if (value == null) // Noncompliant
            {
                return true;
            }
            return false;
        }

        bool IsNull<T>(T value) where T : class
        {
            return value == null;
        }
    }
}
