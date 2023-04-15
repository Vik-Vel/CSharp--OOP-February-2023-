using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private  WeaponRepository weapons;
       

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }


        public double MilitaryPower => Math.Round(CalculateMilitaryPower(),3);

        //Returns  a collection of military units (UnitRepository)
        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        //Returns  a collection of military units (UnitRepository)
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;


        //Adds new MilitaryUnit to the Army. 
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        //Adds new Weapon to the Weapons.
        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }
        //Returns a string with information about the planet in the format below:
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append($"--Forces: ");

            if (Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var units = new Queue<string>();
                foreach (var item in Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }


            sb.Append($"--Combat equipment: ");
            if (Weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var equipment = new Queue<string>();
                foreach (var item in Weapons)
                {
                    equipment.Enqueue(item.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment ));
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");
            
            return sb.ToString().Trim();
        }
        //The  Profit() method should increase the Budget by the given amount.
        public void Profit(double amount)
        {
            Budget += amount;
        }

        //The  Spend() method should decrease the Budget by the given amount.
        //If the Budget is not enough to finish the purchase, throw an InvalidOperationException with a message: "Budget too low!"

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
            
        }
        //The  TrainArmy() method should increase the EnduranceLevel of all forces  in the Army by 1 power point. 
        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }


        private double CalculateMilitaryPower()
        {
            //o	Total amount = (sum of unit endurances + sum of weapon destruction levels)
            double result = units.Models.Sum(x => x.EnduranceLevel) + weapons.Models.Sum(x => x.DestructionLevel);

            //o	If the planet has AnonymousImpactUnit in its military units (Army),  total amount increases with 30%
            if (units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit))) 
            {
                result *= 1.3;
            }
            //o	If the planet has NuclearWeapon in its Weapons , total amount increases with 45%
            if (units.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }
    }
}
