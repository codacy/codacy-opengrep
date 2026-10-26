namespace Tests.Style
{
    public class Empty
    {
        void DoSomething()
        {
            ; // Noncompliant
        }

        void DoSomethingElse(int x)
        {
            System.Console.WriteLine("Hello, world!");;  // Noncompliant
            for (;;)
            {
                break;
            }
            for (int i = 0;; i++)
            {
                break;
            }
            while (x-- > 0) ; // Noncompliant
            do
            {
                x++;
            } while (x < 3);
        }
    }
}
