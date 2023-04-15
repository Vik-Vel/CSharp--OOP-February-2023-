namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            int numOfPopedElements = inputs[1];
            int numWhoLookingFor = inputs[2];

            for (int i = 0; i < numOfPopedElements; i++)
            {
                stack.Pop();
            }

            if (stack.Any())
            {
                if (stack.Contains(numWhoLookingFor))
                {
                    Console.WriteLine(true.ToString().ToLower());
                }
                else
                {
                    int smallestElement = stack.Min();
                    Console.WriteLine(smallestElement);
                }
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}