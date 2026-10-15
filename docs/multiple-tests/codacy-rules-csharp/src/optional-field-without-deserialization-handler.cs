using System;
using System.Runtime.Serialization;

namespace Tests.Bugs
{
    [Serializable]
    public class Foo // Noncompliant
    {
        [OptionalField(VersionAdded = 2)]
        int optionalField = 5;
    }

    [Serializable]
    public class Bar
    {
        [OptionalField(VersionAdded = 2)]
        int optionalField = 5;

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            optionalField = 5;
        }
    }
}
