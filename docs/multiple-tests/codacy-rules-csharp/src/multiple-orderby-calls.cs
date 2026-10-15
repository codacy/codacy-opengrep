using System.Collections.Generic;
using System.Linq;

namespace Tests.Performance
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class Sorting
    {
        void M(List<Person> personList)
        {
            var x = personList
                .OrderBy(person => person.Age)
                .OrderBy(person => person.Name)  // Noncompliant@-2
                .ToList();
            var y = personList.OrderBy(p => p.Age).ThenBy(p => p.Name).ToList();
        }
    }
}
