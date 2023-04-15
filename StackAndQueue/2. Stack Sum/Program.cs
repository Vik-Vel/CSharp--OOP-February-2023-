
namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Stack<int> stack = new Stack<int>(numbers);

            string input;
            while ((input = Console.ReadLine().ToLower())!="end")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "add")
                {
                    stack.Push(int.Parse(tokens[1]));
                    stack.Push(int.Parse(tokens[2]));
                }
                else if (command == "remove")
                {
                    if (stack.Count > int.Parse(tokens[1]))
                    {
                        int num = int.Parse(tokens[1]);
                        for (int i = 0; i < num; i++)
                        {
                            stack.Pop();
                        }
                    }
                    
                   
                }
            }
            

            Console.WriteLine($"Sum: {stack.Sum()}");
            
        }
    }
}