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
        private WeaponRepository weapons;


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
                if (budget < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);
        //Models is from IRepository, and unitrepository/weaponrepository implements 
        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        //The  TrainArmy() method should increase the EnduranceLevel of all forces  in the Army by 1 power point. 
        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;

        }

        public void Profit(double amount)
        {
            foreach (var unit in Army)
            {
                Budget += amount;
            }
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append($"--Forces: ");
            if (Army.Count == 0)
            {
                sb.AppendLine($"No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var unit in Army)
                {
                    units.Enqueue(unit.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }
            sb.Append($"--Combat equipment: ");
            if (Weapons.Count == 0)
            {
                sb.AppendLine($"No weapons");
            }
            else
            {
                var equipment = new Queue<string>();

                foreach (var weapon in Weapons)
                {
                    equipment.Enqueue(weapon.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", equipment));

            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }


        private double CalculateMilitaryPower()
        {
            double result = units.Models.Sum(x => x.EnduranceLevel) + weapons.Models.Sum(x => x.DestructionLevel);


            if (units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result += result * 0.3;
            }

            if (weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result += result * 0.45;
            }

            return result;
        }
    }
}
