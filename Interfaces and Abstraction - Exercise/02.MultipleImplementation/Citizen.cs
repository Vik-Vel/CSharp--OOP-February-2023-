using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo 
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthate;
        }
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
      
    }
}
