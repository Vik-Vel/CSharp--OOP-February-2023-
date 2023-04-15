using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorAndInheritance
{
    public class Student : Person
    {
        //Kogato se vika konstruktora na deteto, predi tova se vika na roditelq

        public Student(string name, int grade) : base(name)
        {
            Console.WriteLine("In Child Constructor");
            Grade = grade;
        }

        public Student(string name) :base( name)
        {
            Console.WriteLine("In cild with name only constructor");
        }
        public int Grade { get; set; }

    }
}
