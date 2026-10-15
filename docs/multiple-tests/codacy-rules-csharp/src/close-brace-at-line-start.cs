namespace Tests.Style
{
    public class Braces
    {
        void M(bool condition)
        {
            if (condition) {
                DoSomething();} // Noncompliant
            if (condition) { DoSomething(); }
            if (condition)
            {
                DoSomething();
            }
            var s = $"value {condition}";
        }

        public int Prop { get; set; }

        void DoSomething() {
        }
    }
}
