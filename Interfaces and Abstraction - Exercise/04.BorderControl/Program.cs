using _04.BorderControl.Interfaces;

namespace _04.BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;

            List<IIdentifiable> society = new(); ;
          

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    Citizens citizens = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    society.Add(citizens);
                }
                else if (tokens.Length == 2)
                {
                    Robots robots = new Robots(tokens[0], tokens[1]);
                    society.Add(robots);
                }
            }
            string invalidIDPart = Console.ReadLine();

            //Проверяваме така дали стринга завършва на даденото парче
            foreach (var element in society)
            {
                if (element.Id.EndsWith(invalidIDPart))
                {
                    Console.WriteLine(element.Id);
                }
            }
        }

    }
}
