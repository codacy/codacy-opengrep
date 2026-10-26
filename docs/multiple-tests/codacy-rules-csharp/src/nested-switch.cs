namespace Tests.Style
{
    class Switches
    {
        void M(int a, int b)
        {
            switch (a)
            {
                case 1:
                    switch (b) // Noncompliant
                    {
                        case 2:
                            Do();
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        void Do() { }
    }
}
