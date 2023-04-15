using FoodShortage.IO;

namespace FoodShortage
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