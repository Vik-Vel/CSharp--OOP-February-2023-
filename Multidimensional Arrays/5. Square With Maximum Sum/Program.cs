namespace _5._Square_With_Maximum_Sum
{
    public class Program
    {
        static void Main(string[] args)
        {

            int squareRows = 2;
            int squareCols = 2;
            int[,] matrix = ReadMatrix();


            int maxSum = matrix[0, 0];
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currSum = 0;

                    if (row > matrix.GetLength(0) - squareCols || col > matrix.GetLength(1) - squareCols)
                    {
                        continue;
                    }

                    for (int squareRow = 0; squareRow < squareRows; squareRow++)
                    {
                        for (int squareCol = 0; squareCol < squareCols; squareCol++)
                        {
                            currSum += matrix[row + squareRow, col + squareCol];
                        }
                    }

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int squareRow = 0; squareRow < squareRows; squareRow++)
            {
                for (int squareCol = 0; squareCol < squareCols; squareCol++)
                {
                    Console.Write(matrix[maxRow + squareRow, maxCol + squareCol] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);

            static int[,] ReadMatrix()
            {
                int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                int rows = rowsAndCols[0];
                int cols = rowsAndCols[1];

                int[,] matrix = new int[rows, cols];

                for (int row = 0; row < rows; row++)
                {
                    int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                        .ToArray();
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = data[col];

                    }
                }

                return matrix;
            }


        }


    }

}