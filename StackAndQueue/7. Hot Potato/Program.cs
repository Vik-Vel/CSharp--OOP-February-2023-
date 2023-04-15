namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split());
            int numOfThrows = int.Parse(Console.ReadLine());

            int throws = 1;
            while (queue.Count > 1)
            {
                string currName = queue.Dequeue();
                if (throws < numOfThrows)
                {
                    throws++;
                    queue.Enqueue(currName);
                }
                else
                {
                    Console.WriteLine($"Remove {currName}");
                    throws = 1;
                }
                
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}