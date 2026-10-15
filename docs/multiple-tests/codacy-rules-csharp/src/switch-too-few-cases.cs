namespace Tests.Style
{
    public class Switches
    {
        int M(int variable)
        {
            switch (variable) // Noncompliant
            {
                case 0:
                    DoSomething();
                    break;
                default:
                    DoSomethingElse();
                    break;
            }

            switch (variable)
            {
                case 0:
                    DoSomething();
                    break;
                case 1:
                    DoSomething();
                    break;
                default:
                    DoSomethingElse();
                    break;
            }

            var foo = variable switch // Noncompliant
            {
                0 => 1,
                _ => 2,
            };

            var bar = variable switch
            {
                0 => 1,
                1 => 3,
                _ => 2,
            };
            return foo + bar;
        }

        void DoSomething() { }
        void DoSomethingElse() { }
    }
}
