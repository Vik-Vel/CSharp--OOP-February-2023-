
using MilitaryElite.IO.Interfaces;


namespace MilitaryElite.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(int line) => Console.WriteLine(line);
        
    }
}
