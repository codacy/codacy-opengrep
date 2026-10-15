using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Tests.Practices
{
    class Saver
    {
        private readonly ILogger logger;

        public bool Save()
        {
            try
            {
                DoSave();
                return true;
            }
            catch (IOException ex)
            {
                logger.LogError("Saving failed."); // Noncompliant
                return false;
            }
        }

        public bool SaveLogged()
        {
            try
            {
                DoSave();
                return true;
            }
            catch (IOException ex)
            {
                logger.LogError(ex, "Saving failed.");
                return false;
            }
        }

        void DoSave() { }
    }
}
