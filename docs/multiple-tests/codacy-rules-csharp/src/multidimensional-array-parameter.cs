namespace Tests.Comprehensibility
{
    public class Program
    {
        public void WriteMatrix(int[][] matrix) // Noncompliant
        {
        }

        public void WriteGrid(int[,] grid) // Noncompliant
        {
        }

        private void UpdateMatrix(int[][] matrix)
        {
        }

        public void WriteRow(int[] row)
        {
        }
    }
}
