using System.Collections.Generic;

namespace Tests.Bugs
{
    class Items
    {
        private List<int> collection = new List<int>();

        public override string ToString()
        {
            if (this.collection.Count == 0)
            {
                return null; // Noncompliant
            }
            return string.Join(",", collection);
        }
    }

    class Empty
    {
        public override string ToString() => null; // Noncompliant
    }

    class Fine
    {
        public override string ToString() => string.Empty;
    }
}
