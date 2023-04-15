using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Models.Interfaces;


namespace FoodShortage.Models
{
    public class Citizens : INameable , IBuyer, IIdentificable,IBirthable
    {
        private const int DefaultFoodIncrement = 10;
        public Citizens(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            Food += DefaultFoodIncrement;
        }
    }
}
