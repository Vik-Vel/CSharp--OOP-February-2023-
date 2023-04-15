using PersonInfo.Models.Interfaces;

namespace PersonInfo.Models
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; }
        public int Age { get; }

    }
}
