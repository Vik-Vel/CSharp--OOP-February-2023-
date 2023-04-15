using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorAndInheritance
{
    public class HighSchoolStudent : Student
    {

        public HighSchoolStudent(string name, int grade, string badRemarks) :base(name, grade)
        {
            Console.WriteLine("In cild of a child");
            BadRemarks = badRemarks;
        }

        public string BadRemarks { get; set; }
    }
}
