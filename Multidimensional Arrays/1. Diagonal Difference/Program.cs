namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    sumPrimaryDiagonal += jaggedArray[row][row];
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                //for (int col = jaggedArray.Length - 1; col >= 0; col--)
                //{
                //    sumSecondaryDiagonal += jaggedArray[row][col];
                //}
                for (int col = 0; col < 1; col++)
                {
                    sumSecondaryDiagonal += jaggedArray[row][jaggedArray.Length-1 - row];
                }
            }

            Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));
        }
    }
}