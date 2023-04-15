namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows  = int.Parse(Console.ReadLine());
            
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] =  Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int givenRow = int.Parse(tokens[1]);
                int givenCol = int.Parse(tokens[2]);
                int num = int.Parse(tokens[3]);


                if (givenRow < 0 || givenCol < 0 || givenRow >= jaggedArray.Length || givenCol >= jaggedArray.Length) 
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command == "Add")
                    {
                        jaggedArray[givenRow][givenCol] += num;
                    }
                    else
                    {
                        jaggedArray[givenRow][givenCol] -= num;
                    }
                }
                
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col] + " "}");

                }

                Console.WriteLine();
            }
            

        }
    }
}