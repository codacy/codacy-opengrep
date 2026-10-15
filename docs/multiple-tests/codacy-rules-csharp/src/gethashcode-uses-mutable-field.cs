namespace Tests.Bugs
{
    public class Person
    {
        public int age;
        public string name;
        private readonly int id;

        public override int GetHashCode()
        {
            int hash = 12;
            hash += this.age.GetHashCode(); // Noncompliant
            hash += name.GetHashCode(); // Noncompliant
            hash += id.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj) => obj is Person p && p.id == id;
    }
}
