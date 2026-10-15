using System.Threading.Tasks;

namespace Tests.Bugs
{
    public static class DeadlockDemo
    {
        private static async Task<int> DelayAsync()
        {
            await Task.Delay(1000);
            return 1;
        }

        public static void Test()
        {
            var value = DelayAsync().Result; // Noncompliant
            DelayAsync().Wait(); // Noncompliant
            DelayAsync().GetAwaiter().GetResult(); // Noncompliant
            var other = new Operation().Result;
        }

        public static async Task Fine()
        {
            var value = await DelayAsync();
        }
    }

    public class Operation
    {
        public int Result { get; set; }
    }
}
