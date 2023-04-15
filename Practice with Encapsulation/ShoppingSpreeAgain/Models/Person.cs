using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpreeAgain.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameExceptionMessage);
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyExceptionMessage);
                }
                money = value;
            }
        }


        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }

            products.Add(product);
            Money -= product.Cost;
            
            return $"{Name} bought {product}";
        }


        public override string ToString()
        {
            string productsString = products.Any()
                ? string.Join(", ", products)
                : "Nothing bought";

            return $"{Name} - {productsString}";
        }
    }
}
