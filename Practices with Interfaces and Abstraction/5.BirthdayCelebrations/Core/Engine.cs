using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;


namespace BirthdayCelebrations
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
            string input;
            List<IBirthable> society = new List<IBirthable>();

            while ((input = reader.ReadLine()) != "End")
            {


                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    IBirthable citizen = new Citizens(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);

                    society.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    IBirthable pet = new Pet(tokens[1], tokens[2]);

                    society.Add(pet);   
                }
               

            }

            string year = reader.ReadLine();

            foreach (var element in society)
            {
                if (element.Birthday.EndsWith(year))
                {
                    writer.WriteLine(element.Birthday);
                }
            }

        }
    }
}
