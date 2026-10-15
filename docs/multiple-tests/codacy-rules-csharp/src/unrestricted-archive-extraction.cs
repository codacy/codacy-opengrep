using System.IO;
using System.IO.Compression;

namespace Tests.Security
{
    class Archives
    {
        void M()
        {
            using var zipToOpen = new FileStream(@"ZipBomb.zip", FileMode.Open);
            using var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                entry.ExtractToFile("./output_onlyfortesting.txt", true); // Noncompliant
            }
        }
    }
}
