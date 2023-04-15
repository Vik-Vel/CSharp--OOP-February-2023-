using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50M;
        

        public Coffee(string name, decimal price, double milliliters, double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
