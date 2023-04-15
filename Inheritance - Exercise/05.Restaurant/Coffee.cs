using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {

        //Слагаме ги, защото са дадени в условието и ще са едни и същи, също така няма да ни трябват да се променят за по-напре, за това ги като слагаме прайвът константи
        private const decimal CoffeePrice = 3.50M;
        private const double CoffeeMilliliters = 50;

        //Тук оставяме да преизползваме името, добавяме милилитрите и след като ние сме ги добавили тук в този клас си ги пишем тях, а не взимаме от базовия конструктор
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = caffeine;
        }


       public double Caffeine { get; private set; }
    }
}
