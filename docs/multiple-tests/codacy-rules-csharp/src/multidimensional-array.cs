namespace Tests.Performance
{
    class Arrays
    {
        void M()
        {
            int[,] myArray =  // Noncompliant
                {
                    {1, 2, 3, 4},
                    {5, 6, 7, 0}
                };
            int[][] jagged = new int[2][];
            System.Console.WriteLine(myArray[1, 1] + jagged.Length);
        }
    }
}
