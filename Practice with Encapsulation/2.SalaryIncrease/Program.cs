using System;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var commandArguments = Console.ReadLine().Split();
                var person = new Person(commandArguments[0], commandArguments[1], int.Parse(commandArguments[2]), decimal.Parse(commandArguments[3]));
                persons.Add(person);
            }
            decimal percentage = decimal.Parse(Console.ReadLine()); 

            persons.ForEach(p => p.IncreaseSalary(percentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            

        }
    }
}