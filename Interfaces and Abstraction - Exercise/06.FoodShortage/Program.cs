using FoodShortage;
using FoodShortage.Model;
using FoodShortage.Model.Interfaces;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;

            List<IBuyer> society = new(); ;


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    Citizens citizens = new(tokens[0], int.Parse(tokens[1]), tokens[2], tokens [3]);
                    society.Add(citizens);

                }
                else
                {
                    Rebel rebel = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    society.Add(rebel);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                society.FirstOrDefault(society => society.Name == input)?.BuyFood();

            }
            Console.WriteLine(society.Sum(b => b.Food));
        }

    }
}
