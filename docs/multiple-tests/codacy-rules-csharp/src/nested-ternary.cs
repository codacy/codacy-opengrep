namespace Tests.Comprehensibility
{
    class Job
    {
        public bool IsRunning { get; set; }
        public bool HasErrors { get; set; }
    }

    class Status
    {
        public string GetReadableStatus(Job j)
        {
            return j.IsRunning ? "Running" : j.HasErrors ? "Failed" : "Succeeded";  // Noncompliant
        }

        public string Simple(Job j)
        {
            return j.IsRunning ? "Running" : "Idle";
        }
    }
}
