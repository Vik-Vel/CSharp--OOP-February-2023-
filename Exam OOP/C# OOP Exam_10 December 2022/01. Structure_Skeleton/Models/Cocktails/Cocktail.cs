using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        // private List<string> sizes;

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
            //sizes = new List<string> { "Small", "Middle", "Large" };
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }
        public string Size
        {
            get => size;
            private set => size = value;
        }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }
                else if (Size == "Middle")
                {
                    price = price * 2.0 / 3.0;
                }

                else if (Size == "Large")
                {
                    price = price * 1.0 / 3.0;
                }
            }

        }

        public override string ToString()
        {
            return $"{Name} ({size}) - {Price:f2} lv";
        }
    }
}
