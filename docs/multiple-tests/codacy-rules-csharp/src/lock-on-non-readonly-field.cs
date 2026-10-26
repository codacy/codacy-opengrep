namespace Tests.Bugs
{
    class Color
    {
        public Color(string name) { }
    }

    class Locks
    {
        private Color color = new Color("red");
        private readonly object sync = new object();

        private void DoSomething()
        {
            lock (color) // Noncompliant
            {
                Paint();
            }
            lock (new object()) // Noncompliant
            {
                Paint();
            }
            lock (sync)
            {
                Paint();
            }
        }

        void Paint() { }
    }
}
