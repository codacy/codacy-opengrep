using System;

namespace Tests.Performance
{
    struct MyStruct  // Noncompliant
    {
        public int Value { get; set; }
    }

    struct Proper : IEquatable<Proper>
    {
        public int Value { get; set; }
        public bool Equals(Proper other) => Value == other.Value;
    }

    ref struct SpanLike
    {
        public int Value;
    }
}
