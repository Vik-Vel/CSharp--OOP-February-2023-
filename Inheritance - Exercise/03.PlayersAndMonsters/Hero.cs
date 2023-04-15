using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string username, int level)
        {
            UserName = username;
            Level = level;
        }
        public string UserName { get; set; }
        public int Level { get; set; }


        public override string ToString()
        {
            return $"Type: {GetType().Name} Username: {UserName} Level: {Level}";
        }
    }
}
