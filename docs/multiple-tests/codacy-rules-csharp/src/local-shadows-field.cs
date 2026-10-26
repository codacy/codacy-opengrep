namespace Tests.Style
{
    public class Foo
    {
        public int myField;
        private string other = "x";
        public int MyProperty { get; set; }

        public void DoSomething()
        {
            int myField = 0; // Noncompliant
            int MyProperty = 1; // Noncompliant
            string other; // Noncompliant
            int unrelated = 2;
        }

        public static void Create()
        {
            int myField = 3;
        }
    }
}
