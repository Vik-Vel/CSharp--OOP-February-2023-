
namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);
           // Stack<int> queue = new Stack<int>(numbers);

            int numOfPopedElements = inputs[1];
            int numWhoLookingFor = inputs[2];

            for (int i = 0; i < numOfPopedElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Any())
            {
                if (queue.Contains(numWhoLookingFor))
                {
                    Console.WriteLine(true.ToString().ToLower());
                }
                else
                {
                    int smallestElement = queue.Min();
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