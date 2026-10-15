namespace Tests.Practices
{
    public class Todos
    {
        private void DoSomething()
        {
            // TODO // Noncompliant
        }

        /*
         * TODO: support the new format // Noncompliant
         */
        private void Todolist() { }
    }
}
