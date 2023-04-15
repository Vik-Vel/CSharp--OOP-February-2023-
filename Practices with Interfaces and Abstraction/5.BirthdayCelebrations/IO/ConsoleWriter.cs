
using BirthdayCelebrations.IO.Interfaces;


namespace BirthdayCelebrations.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
        
    }
}
