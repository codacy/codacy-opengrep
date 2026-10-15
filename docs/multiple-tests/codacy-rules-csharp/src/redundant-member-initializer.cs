namespace Tests.Style
{
    class Person
    {
        int age = 42; // Noncompliant

        public Person(int age)
        {
            this.age = age;
        }
    }

    class TwoConstructors
    {
        int count = 1;

        public TwoConstructors() { }

        public TwoConstructors(int count)
        {
            this.count = count;
        }
    }
}
