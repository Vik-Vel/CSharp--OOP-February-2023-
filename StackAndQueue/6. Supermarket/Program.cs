namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Queue<string> names = new Queue<string>();


            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    foreach (var item in names)
                    {
                        Console.WriteLine(item);
                    }
                    names.Clear();
                }
                else
                {
                    names.Enqueue(input);
                }
                
            
            }
            
            Console.WriteLine($"{names.Count} people remaining");
            
            
        }
    }
}