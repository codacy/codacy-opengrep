namespace Tests.Security
{
    class Unsafe
    {
        public unsafe int SubarraySum(int[] array, int start, int end)  // Noncompliant
        {
            var sum = 0;
            fixed (int* firstNumber = array)
            {
                for (int i = start; i < end; i++)
                {
                    sum += *(firstNumber + i);
                }
            }
            return sum;
        }

        // this method is not unsafe
        public int Safe(int[] array) => array.Length;
    }
}
