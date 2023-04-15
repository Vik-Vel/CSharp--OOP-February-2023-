using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    internal class Program
    {
        static void Main(string[] args)
        {
           IEngine engine = new Engine();
           engine.Run();
        }
    }
}