namespace Tests.Style
{
    public class Positions
    {
        void M(int param)
        {
            switch (param)
            {
                case 0:
                    DoSomething();
                    break;
                default: // Noncompliant
                    Error();
                    break;
                case 1:
                    DoSomethingElse();
                    break;
            }

            switch (param)
            {
                default:
                    Error();
                    break;
                case 0:
                    DoSomething();
                    break;
            }
        }

        void DoSomething() { }
        void DoSomethingElse() { }
        void Error() { }
    }
}
