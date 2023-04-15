using _05.BirthdayCelebrations.Model;
using _05.BirthdayCelebrations.Model.Interfaces;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;

            List<IBirthdable> society = new(); ;
          

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string kind = tokens[0];

                if (kind == "Citizen")
                {
                    IBirthdable citizens = new Citizens(tokens[1], int.Parse(tokens[2]), tokens[3],tokens[4]);
                    society.Add(citizens);
                }
                else if (kind == "Pet")
                {
                    Pet pet = new Pet(tokens[1], tokens[2]);
                    society.Add(pet);
                }
               
            }
            string year = Console.ReadLine();

            //Проверяваме така дали стринга завършва на даденото парче
            foreach (var element in society)
            {
                if (element.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(element.Birthdate);
                }
            }
        }

    }
}
