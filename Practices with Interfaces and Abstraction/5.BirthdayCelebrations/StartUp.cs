using BirthdayCelebrations.IO;

namespace BirthdayCelebrations
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}