using System.IO;

namespace Tests.Style
{
    class Parentheses
    {
        void M(int y, bool a, int z, TextReader reader)
        {
            int x = ((y / 2 + 1)); // Noncompliant
            if (a && ((z + y > 0))) // Noncompliant
            {
                x++;
            }
            if ((a && z > 0) || y > 1)
            {
                x++;
            }
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                x++;
            }
            Use((int)x);
        }

        void Use(int v) { }
    }
}
