using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double FishGrams = 22;


        //Тук имаме дефолтна стойност 22, която не може да се промени от отвън, тя винаги ще е 22, за това в -> Fish(string name, decimal price) не добавяме още една променлива, защото не искаме да я подменят от отвън, за това взимаме базовия клас и на 3тата стойност автоматично се създава 22 - НЕ ЧАКАМЕ ОТ ОТВЪН
        public Fish(string name, decimal price) : base(name, price, FishGrams)
        {

        }

       
    }
}
