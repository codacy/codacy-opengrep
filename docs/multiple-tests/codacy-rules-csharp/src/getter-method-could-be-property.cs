using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Practices
{
    public class Foo
    {
        private string name;

        public string GetName()  // Noncompliant
        {
            return name;
        }

        public string[] GetNames() => new[] { name };

        public Task<string> GetNameAsync() => Task.FromResult(name);

        public IEnumerator<string> GetEnumerator() => null;

        public string GetFormatted(string format) => name;
    }
}
