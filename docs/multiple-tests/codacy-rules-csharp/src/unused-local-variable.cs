using System.IO;

namespace Tests.Unused
{
    public class Locals
    {
        public int NumberOfMinutes(int hours)
        {
            int seconds = 0;   // Noncompliant
            int minutes = hours * 60;
            return minutes;
        }

        public void UsingResource(string path)
        {
            using (var t = File.OpenRead(path))
            {
            }
            var used = path.Length;
            if (used > 3)
            {
                System.Console.WriteLine(path);
            }
        }
    }
}
