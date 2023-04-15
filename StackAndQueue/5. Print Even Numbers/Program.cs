namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

           Queue<int> newQueue = new Queue<int>();

           while (queue.Count > 0)
           {
              
               int currNum = queue.Dequeue();
               if (currNum % 2 == 0)
               {
                   //int currNum = queue.Dequeue();
                   newQueue.Enqueue(currNum);
                  
               }
               
            }

           Console.WriteLine(string.Join(", ",newQueue));
        }
    }
}