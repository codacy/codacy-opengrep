using System.Collections.Generic;

namespace Tests.Practices
{
    public class Result { }

    public class Results
    {
        public Result[] GetResults()
        {
            return null; // Noncompliant
        }

        public IEnumerable<Result> GetResults(bool condition)
        {
            if (condition)
            {
                return null; // Noncompliant
            }
            return new List<Result>();
        }

        public string GetName()
        {
            return null;
        }

        public Result GetOne()
        {
            return null;
        }
    }
}
