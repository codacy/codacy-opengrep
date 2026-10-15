namespace Tests.Bugs
{
    public class Blocks
    {
        void M(bool condition)
        {
            if (condition)
                FirstActionInBlock();
                SecondAction(); // Noncompliant

            if (condition) FirstActionInBlock(); SecondAction(); // Noncompliant

            if (condition)
                FirstActionInBlock();
            SecondAction();

            if (condition)
            {
                FirstActionInBlock();
                SecondAction();
            }
        }

        void FirstActionInBlock() { }
        void SecondAction() { }
    }
}
