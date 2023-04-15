namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                    sum += data[col];
                }
            }

            Console.WriteLine($"{rows}");
            Console.WriteLine($"{cols}");
            Console.WriteLine($"{sum}");

        }
    }
}