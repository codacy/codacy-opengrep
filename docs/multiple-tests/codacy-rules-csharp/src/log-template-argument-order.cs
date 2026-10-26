using System.IO;
using Microsoft.Extensions.Logging;

namespace Tests.Bugs
{
    class Logging
    {
        private readonly ILogger logger;

        void M(string path, string fileName, FileInfo file)
        {
            logger.LogError("File {FileName} not found in folder {Path}", path, fileName); // Noncompliant
            logger.LogError("File {FileName} not found in folder {Path}", fileName, path);
            logger.LogError("File {Name} not found in folder {Folder}", file.DirectoryName, file.Name);
        }
    }
}
