namespace Tests.Bugs
{
    class Conditions
    {
        public void Sample(bool b, bool c)
        {
            var a = true;
            if (a) // Noncompliant
            {
                DoSomething();
            }
            var x = a ? 1 : 2; // Noncompliant
            if (true)
            {
                DoSomething();
            }
            if (b)
            {
                DoSomething();
            }
        }

        void DoSomething() { }
    }
}
