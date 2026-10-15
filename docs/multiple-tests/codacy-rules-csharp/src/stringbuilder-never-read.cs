using System.Collections.Generic;
using System.Text;

namespace Tests.Performance
{
    class Builders
    {
        public void DoSomething(List<string> strings)
        {
            var sb = new StringBuilder();  // Noncompliant
            sb.Append("Got: ");
            foreach (var str in strings)
            {
                sb.Append(str).Append(", ");
            }
        }

        public string Used(List<string> strings)
        {
            var sb = new StringBuilder();
            foreach (var str in strings)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }

        public void Passed()
        {
            var sb = new StringBuilder();
            sb.Append("x");
            Write(sb);
        }

        void Write(StringBuilder sb) { }
    }
}
