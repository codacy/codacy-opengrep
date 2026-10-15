using System.Collections.Generic;
using System.Linq;

namespace Tests.Style
{
    class Car { }

    class Linq
    {
        void M(List<object> seq, List<int> numbers)
        {
            var result1 = seq.Select(x => x as Car).Any(x => x != null); // Noncompliant
            var result4 = seq.Where(x => x is Car).Select(x => (Car)x); // Noncompliant
            var any = numbers.Where(n => n > 3).Any(); // Noncompliant
            var fine = numbers.Any(n => n > 3);
            var cars = seq.OfType<Car>();
        }
    }
}
