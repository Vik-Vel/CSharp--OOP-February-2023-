using _05.BirthdayCelebrations.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations.Model
{
    public class Pet : INameable, IBirthdable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; }
        public string Birthdate { get; }


    }
}
