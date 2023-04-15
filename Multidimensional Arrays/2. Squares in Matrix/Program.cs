namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countEqualsCells = 0;

            string[] rowsAndCols = Console.ReadLine().Split();

            int rows = int.Parse(rowsAndCols[0]);

            int cols = int.Parse(rowsAndCols[1]);

            string[][] jaggedArray = new string[rows][];
            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split();
            }

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (jaggedArray[row][col] == jaggedArray[row + 1][col + 1]
                        && jaggedArray[row + 1][col + 1]== jaggedArray[row][col+1] 
                        && jaggedArray[row][col + 1] == jaggedArray[row + 1][col] 
                        && jaggedArray[row + 1][col] == jaggedArray[row][col])
                    {
                        countEqualsCells++;
                    }
                }
            }

            Console.WriteLine(countEqualsCells);
        }
    }
}