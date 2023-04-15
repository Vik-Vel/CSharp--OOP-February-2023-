using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reservedTeam = new List<Person>();
        }
        
        private string name;

        public string Name
        {
            get { return name; }
           private set { name = value; }
        }

        private List<Person> firstTeam;

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
        }
        private List<Person> reservedTeam;

        public IReadOnlyCollection<Person> ReservedTeam
        {
            get { return firstTeam.AsReadOnly(); }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reservedTeam.Add(person);
            }
        }


        public override string ToString()
        {
            return $"First team has {firstTeam.Count} players.{Environment.NewLine}Reserve team has {reservedTeam.Count} players.";
        }


    }
}
