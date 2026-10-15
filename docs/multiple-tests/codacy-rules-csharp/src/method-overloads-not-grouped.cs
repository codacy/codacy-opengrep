namespace Tests.Style
{
    class MyClass
    {
        public int DoTheThing()
        {
            return 1;
        }

        public string DoTheOtherThing()
        {
            return "x";
        }

        public int DoTheThing(int x) // Noncompliant
        {
            return x;
        }
    }
}
