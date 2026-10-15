namespace Tests.Bugs
{
    public delegate string AsyncMethodCaller();

    public class Program
    {
        public static void Main()
        {
            AsyncMethodCaller caller = () => "x";
            var result = caller.BeginInvoke(null, null); // Noncompliant
        }

        public static void Fine()
        {
            AsyncMethodCaller caller = () => "x";
            var asyncResult = caller.BeginInvoke(null, null);
            var value = caller.EndInvoke(asyncResult);
        }
    }
}
