namespace Tests.Practices
{
    public class Blocks
    {
        public void Evaluate(int x)
        {
            var a = x;
            { // Noncompliant
                int b = a + 1;
                Use(b);
            }
            switch (x)
            {
                case 1:
                {
                    Use(x);
                    break;
                }
                default:
                    break;
            }
            var list = new System.Collections.Generic.Dictionary<int, int>
            {
                { 1, 2 },
            };
        }

        void Use(int v) { }
    }
}
