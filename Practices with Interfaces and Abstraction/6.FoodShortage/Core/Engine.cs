using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;


namespace FoodShortage
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            

            int lines = int.Parse(reader.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    Citizens person = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);

                    buyers.Add(person);
                }
                else if (tokens.Length == 3)
                {
                    Rebels rebels = new Rebels(tokens[0], int.Parse(tokens[1]), tokens[2]);

                    buyers.Add(rebels);
                }
            }

            string input;

            while ((input = reader.ReadLine())!= "End")
            {
               buyers.FirstOrDefault(x => x.Name == input)?.BuyFood();
            }

            writer.WriteLine(buyers.Sum(b => b.Food));
        }
        
    }
}
