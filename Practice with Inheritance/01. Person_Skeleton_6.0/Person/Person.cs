using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Person
{
    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 || value <= 15)
                {
                    age = value;
                }
                
            }
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                Name,
                Age));

            return stringBuilder.ToString();
        }

    }
}
