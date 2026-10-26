using System;

namespace Tests.Bugs
{
    public class Person
    {
        private static DateTime dateOfBirth;
        private static int expectedFingers;
        private int age;

        public Person(DateTime birthday)
        {
            dateOfBirth = birthday; // Noncompliant
            expectedFingers = 10; // Noncompliant
            age = 1;
        }

        static Person()
        {
            expectedFingers = 10;
        }
    }
}
