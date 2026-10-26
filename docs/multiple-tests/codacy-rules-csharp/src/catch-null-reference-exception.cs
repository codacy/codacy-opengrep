using System;

namespace Tests.Bugs
{
    class Catches
    {
        public int GetLengthPlusTwo(string str)
        {
            try
            {
                return str.Length + 2;
            }
            catch (NullReferenceException e) // Noncompliant
            {
                return 2;
            }
        }

        public int Other(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch (System.NullReferenceException) // Noncompliant
            {
                return 0;
            }
            catch (FormatException)
            {
                return -1;
            }
        }
    }
}
