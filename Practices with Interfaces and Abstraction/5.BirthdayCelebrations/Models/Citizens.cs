using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayCelebrations.Models.Interfaces;


namespace BirthdayCelebrations.Models
{
    public class Citizens : IIdentificable, IBirthable
    {

        public Citizens(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthday { get; }
    }
}
