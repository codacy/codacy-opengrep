namespace Tests.Practices
{
    public class Person
    {
        private int _birthYear; // Noncompliant
        private int _age;
        private string _name = "x"; // Noncompliant
        private readonly int _id;

        Person(int birthYear, int id)
        {
            _birthYear = birthYear;
            _id = id;
        }

        public void Birthday()
        {
            _age++;
        }

        private object _lazy;
        public object Lazy => _lazy ?? (_lazy = new object());
        private int _neverAssigned;

        public int Compute() => _birthYear + _age + _id + _name.Length + _neverAssigned;
    }
}
