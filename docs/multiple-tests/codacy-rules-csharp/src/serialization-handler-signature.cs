using System;
using System.Runtime.Serialization;

namespace Tests.Bugs
{
    [Serializable]
    public class Foo
    {
        [OnSerializing]
        public void OnSerializing(StreamingContext context) { } // Noncompliant

        [OnSerialized]
        int OnSerialized(StreamingContext context) { return 1; } // Noncompliant

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) { }

        [OnDeserialized]
        private void OnDeserialized() { } // Noncompliant
    }
}
