namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> openBracketIndexes = new Stack<int>();


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBracketIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int openBracket = openBracketIndexes.Pop();

                    for (int j = openBracket; j <= i; j++)
                    {
                        Console.Write(input[j]);
                    }
                    Console.WriteLine();
                }


            }


        }
    }
}