namespace Tests.Practices
{
    public class Methods
    {
        public void ShouldNotBeEmpty() {
        } // Noncompliant@-1

        public void NotImplementedYet()
        {
        } // Noncompliant@-2

        public void EmptyOnPurpose()
        {
            // comment explaining why the method is empty
        }

        public virtual void Hook()
        {
        }

        public void Implemented()
        {
            ShouldNotBeEmpty();
        }
    }
}
