namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int sum = 0;

            Stack<string> stack = new Stack<string>(input);

           Stack<string> reversedStack = new Stack<string>();

           while (stack.Count > 0)
           {
               for (int i = stack.Count - 1; i >= 0; i--)
               {
                   reversedStack.Push(stack.Pop());
               }
           }
           
            for (int i = 0; i < reversedStack.Count; i++)
            {
                
                if (i == 0)
                {
                    sum = int.Parse(reversedStack.Pop());
                    i=0;
                    

                }
                else if (reversedStack.Peek() == "+")
                {
                    reversedStack.Pop();
                    sum += int.Parse(reversedStack.Pop());
                    i = 0;
                }
                else if (reversedStack.Peek() == "-")
                {
                    reversedStack.Pop();
                    sum -= int.Parse(reversedStack.Pop());
                    i = 0;
                }

                
            }

            Console.WriteLine(sum);



        }
    }
}