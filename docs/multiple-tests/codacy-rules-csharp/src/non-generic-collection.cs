using System.Collections;
using System.Collections.Generic;

namespace Tests.Practices
{
    public class MyData { }

    public class MyList : CollectionBase // Noncompliant
    {
        public void Add(MyData data) { InnerList.Add(data); }
    }

    public class TypedList : CollectionBase, ICollection<MyData>
    {
        public bool IsReadOnly => false;
        public void Add(MyData item) { }
        public bool Contains(MyData item) => false;
        public void CopyTo(MyData[] array, int arrayIndex) { }
        public bool Remove(MyData item) => false;
        public new IEnumerator<MyData> GetEnumerator() => null;
    }
}
