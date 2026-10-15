using System;
using System.Runtime.Serialization;

namespace Tests.Bugs
{
    public class Foo : ISerializable // Noncompliant
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context) { }
    }

    [Serializable]
    public class Bar : ISerializable
    {
        public Bar() { }
        protected Bar(SerializationInfo info, StreamingContext context) { }
        public void GetObjectData(SerializationInfo info, StreamingContext context) { }
    }
}
