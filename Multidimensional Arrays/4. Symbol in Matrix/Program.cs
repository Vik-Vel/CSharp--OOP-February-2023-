namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowsAndCols, rowsAndCols];

           

            for (int row = 0; row < rowsAndCols; row++)
            {
                string input = Console.ReadLine();
                char[] symbols = input.ToCharArray();
                
                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = symbols[col];

                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < rowsAndCols; row++)
            {

                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            
            Console.WriteLine($"{symbol} does not occur in the matrix ");

        }
    }
}