namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = data[col];

                }
            }

            int sum = 0;
            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }


                }
            }

            Console.WriteLine(sum);

        }
    }
}