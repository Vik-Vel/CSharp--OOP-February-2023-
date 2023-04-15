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
           

            Team team = new Team("SoftUni");
            

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team);
        }
    }
}