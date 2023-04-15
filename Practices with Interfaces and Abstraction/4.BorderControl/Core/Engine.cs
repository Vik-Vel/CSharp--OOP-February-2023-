using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
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
            List<IIdentificable> allRobotsAndCitizensId = new List<IIdentificable>();
            while ((input = reader.ReadLine()) != "End")
            {
              

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    IIdentificable citizen = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2]);

                    allRobotsAndCitizensId.Add(citizen);
                }
                else if (tokens.Length == 2)
                {
                    IIdentificable robot = new Robots(tokens[0], tokens[1]);

                    allRobotsAndCitizensId.Add(robot);
                }
            }

            string fakeIds = reader.ReadLine();

            foreach (var element in allRobotsAndCitizensId)
            {
                if (element.Id.EndsWith(fakeIds))
                {
                    writer.WriteLine(element.Id);
                }
            }

        }
    }
}
