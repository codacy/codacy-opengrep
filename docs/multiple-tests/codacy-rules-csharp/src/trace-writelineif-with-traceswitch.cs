using System.Diagnostics;

namespace Tests.Practices
{
    class Switches
    {
        void M(TraceSwitch traceSwitch)
        {
            Trace.WriteLineIf(traceSwitch.TraceError, "An error occurred."); // Noncompliant
            Trace.WriteLineIf(traceSwitch.TraceWarning, "A warning occurred."); // Noncompliant
            if (traceSwitch.TraceError)
            {
                Trace.TraceError("An error occurred.");
            }
        }
    }
}
