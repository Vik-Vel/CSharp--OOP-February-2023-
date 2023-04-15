using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Food : Product
    {
        //Извикваме конструктор с 3 параметъра и преизползваме класа на родителя, за това добавяме само новия параметър 
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }

       
        public double Grams { get; set; }
    }
}
