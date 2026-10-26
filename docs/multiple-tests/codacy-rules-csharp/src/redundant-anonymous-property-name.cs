namespace Tests.Style
{
    public class Anonymous
    {
        public int Y { get; set; }

        void M(Anonymous other)
        {
            var X = 5;
            var anon = new
            {
                X = X, // Noncompliant
                Y = other.Y, // Noncompliant
                Z = "my string"
            };
        }
    }
}
