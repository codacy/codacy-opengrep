namespace Tests.Practices
{
    public class MyClass { }

    public class Replies
    {
        public void GetReply( // Noncompliant
            ref MyClass input,
            out string reply)
        {
            reply = "x";
        }

        public bool TryParse(string s, out int value)
        {
            value = 0;
            return true;
        }

        private void Internal(ref int x)
        {
        }
    }
}
