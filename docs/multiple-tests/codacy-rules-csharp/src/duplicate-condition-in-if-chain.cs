namespace Tests.Bugs
{
    class Chains
    {
        void M(int param)
        {
            if (param == 1)
            {
                OpenWindow();
            }
            else if (param == 2)
            {
                CloseWindow();
            }
            else if (param == 1) // Noncompliant
            {
                MoveWindowToTheBackground();
            }

            if (param == 1)
            {
                OpenWindow();
            }
            else if (param == 3)
            {
                CloseWindow();
            }
        }

        void OpenWindow() { }
        void CloseWindow() { }
        void MoveWindowToTheBackground() { }
    }
}
