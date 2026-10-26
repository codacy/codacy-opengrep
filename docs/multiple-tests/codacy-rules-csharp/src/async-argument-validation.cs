using System;
using System.IO;
using System.Threading.Tasks;

namespace Tests.Bugs
{
    static class AsyncValidation
    {
        public static async Task SkipLinesAsync(this TextReader reader, int linesToSkip)
        {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); } // Noncompliant
            for (var i = 0; i < linesToSkip; ++i)
            {
                await reader.ReadLineAsync();
            }
        }

        public static Task SkipLines(this TextReader reader, int linesToSkip)
        {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            return reader.ReadLineAsync();
        }
    }
}
