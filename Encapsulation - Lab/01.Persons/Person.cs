using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; } //pravim go private za da ne moje da se ima dostup ot otvun i shte napravim dostup samo prez konstruktor
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }


        private int age;

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public override string ToString()
        {
            //Vzimame publichnite propertita
            return $"{FirstName} {LastName} is {Age} years old.";
        }

    }
}
