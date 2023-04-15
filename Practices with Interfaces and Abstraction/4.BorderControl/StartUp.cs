using BorderControl.Core;
using BorderControl.IO;

namespace _4.BorderControl
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