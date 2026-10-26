using System;

namespace Tests.Practices
{
    public interface IClock
    {
        DateTime UtcNow();
    }

    public class Foo
    {
        public string HelloTime() =>
            $"Hello at {DateTime.UtcNow}"; // Noncompliant

        public string HelloClock(IClock clock) =>
            $"Hello at {clock.UtcNow()}";
    }
}
