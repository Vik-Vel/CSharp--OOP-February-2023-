using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public  Private(int id, string firstName, string lastName, decimal salary) : base(id,firstName,lastName)
        {
            Salary = salary;
        }
        public decimal Salary { get; private set; }

    }
}
