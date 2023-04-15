using CollectionHierarchy.Core;
using CollectionHierarchy.Core.Interfaces;

namespace CollectionHierarchy
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