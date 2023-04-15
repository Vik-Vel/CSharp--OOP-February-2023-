
using FoodShortage.IO.Interfaces;


namespace FoodShortage.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(int line) => Console.WriteLine(line);
        
    }
}
