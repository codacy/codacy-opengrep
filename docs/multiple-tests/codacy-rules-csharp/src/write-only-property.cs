namespace Tests.Practices
{
    class Program
    {
        private int foo;

        public int Foo  //Noncompliant
        {
            set
            {
                foo = value;
            }
        }

        public int Bar
        {
            get { return foo; }
            set { foo = value; }
        }
    }
}
