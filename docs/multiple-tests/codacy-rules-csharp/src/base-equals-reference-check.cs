namespace Tests.Bugs
{
    class Base
    {
        private int baseField;

        public override bool Equals(object other)
        {
            if (base.Equals(other))
            {
                return true;
            }
            return this.baseField == ((Base)other).baseField;
        }

        public override int GetHashCode() => baseField;
    }

    class Derived : Base
    {
        private int derivedField;

        public override bool Equals(object other)
        {
            bool same = base.Equals(other); // Noncompliant
            return same && this.derivedField == ((Derived)other).derivedField;
        }

        public override int GetHashCode() => derivedField;
    }
}
