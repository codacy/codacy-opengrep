namespace Tests.Bugs
{
    public class Choice
    {
        private bool selected;

        public void MakeChoice(bool selected)
        {
            selected = selected; // Noncompliant
        }

        public void Fixed(bool selected)
        {
            this.selected = selected;
        }
    }
}
