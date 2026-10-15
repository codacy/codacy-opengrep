namespace Tests.Style
{
    public class Cases
    {
        void M(char ch)
        {
            switch (ch)
            {
                case 'a':
                    HandleA();
                    break;
                case 'b':
                    HandleB();
                    break;
                case 'c':  // Noncompliant
                default:
                    HandleTheRest();
                    break;
            }
        }

        void HandleA() { }
        void HandleB() { }
        void HandleTheRest() { }
    }
}
