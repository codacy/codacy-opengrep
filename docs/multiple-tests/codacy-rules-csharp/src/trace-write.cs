using System;
using System.Diagnostics;

namespace Tests.Practices
{
    class Tracing
    {
        void M()
        {
            try
            {
                var message = Retrieve();
                Trace.Write($"Message received: {message}"); // Noncompliant
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }

        string Retrieve() => "x";
    }
}
