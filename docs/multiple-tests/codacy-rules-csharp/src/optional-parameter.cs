namespace Tests.Practices
{
    public class Notifier
    {
        public void Notify(string company, string office = "QJZ") // Noncompliant
        {
        }

        private void Internal(string company, string office = "QJZ")
        {
        }

        public void Overload(string company)
        {
        }
    }
}
