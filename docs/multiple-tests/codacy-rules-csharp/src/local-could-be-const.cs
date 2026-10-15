namespace Tests.Practices
{
    class Consts
    {
        public bool Seek(int[] input)
        {
            var target = 32;  // Noncompliant
            foreach (int i in input)
            {
                if (i == target)
                {
                    return true;
                }
            }
            var counter = 0;
            foreach (int i in input)
            {
                counter++;
            }
            return counter > 0;
        }
    }
}
