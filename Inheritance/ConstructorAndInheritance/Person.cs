using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorAndInheritance
{
    public class Person
    {
        //Kogato se vika konstruktora na deteto, predi tova se vika na roditelq
        public Person(string name) //constructor
        {
            Console.WriteLine("In Base Constructor");
            Name = name;
        }

        public string Name { get; set; }
    }
}
