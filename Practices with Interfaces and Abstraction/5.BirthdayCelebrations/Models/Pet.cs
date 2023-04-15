using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {

        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        public string Name { get; }
        public string Birthday { get; }
    }
}
