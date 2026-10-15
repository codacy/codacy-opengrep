using System.Diagnostics.Contracts;

namespace Tests.Bugs
{
    class Person
    {
        private int age;

        [Pure] // Noncompliant@+1
        void ConfigureAge(int age) =>
            this.age = age;

        [Pure]
        int GetAge() => age;
    }
}
