using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller:IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet,name);
            }
            else 
            {
                planets.AddItem(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
           

        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }
            //Puskame proverki na vsichkite child classes na MilitaryUnits
            IMilitaryUnit unit;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else 
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName,weaponTypeName);

        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            else if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }
            else
            {
                double reduceBudget = 1.25;
                planet.TrainArmy();
                planet.Spend(reduceBudget);

                return string.Format(OutputMessages.ForcesUpgraded, planetName);
            }
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            bool isPlanetOneHaveNuclearWeapon = firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));
            bool isPlanetTwoHaveNuclearWeapon = secondPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));

            var firstNuclear = firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == nameof(NuclearWeapon));
            var secondNuclear = secondPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == nameof(NuclearWeapon));

            //all forces costs and/+ weapons prices 
            double firstCalculatedValue = firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(y => y.Price);
            double secondCalculatedValue = secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(y => y.Price);

            double firstMilitaryPower = firstPlanet.MilitaryPower;
            double secondMilitaryPower = secondPlanet.MilitaryPower;
            
            double halfBudgetFirstPlanet = firstPlanet.Budget / 2;
            double halfBudgetSecondPlanet = secondPlanet.Budget / 2;


            if (firstMilitaryPower > secondMilitaryPower)
            {
               firstPlanet.Spend(halfBudgetFirstPlanet);
               firstPlanet.Profit(halfBudgetSecondPlanet);
               firstPlanet.Profit(secondCalculatedValue);

               planets.RemoveItem(secondPlanet.Name);
               return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (secondMilitaryPower > firstMilitaryPower)
            {
                secondPlanet.Spend(halfBudgetSecondPlanet);
                secondPlanet.Profit(halfBudgetFirstPlanet);
                secondPlanet.Profit(firstCalculatedValue);

                planets.RemoveItem(firstPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            else 
            {
                if (firstNuclear != null && secondNuclear != null)
                {
                    firstPlanet.Spend(halfBudgetFirstPlanet);
                    secondPlanet.Spend(halfBudgetSecondPlanet);

                    return string.Format(OutputMessages.NoWinner);

                }
                else if (firstNuclear == null && secondNuclear == null)
                {
                    firstPlanet.Spend(halfBudgetFirstPlanet);
                    secondPlanet.Spend(halfBudgetSecondPlanet);

                    return string.Format(OutputMessages.NoWinner);
                }
                else if(firstNuclear != null)
                {
                    firstPlanet.Spend(halfBudgetFirstPlanet);
                    firstPlanet.Profit(halfBudgetSecondPlanet);
                    firstPlanet.Profit(secondCalculatedValue);

                    planets.RemoveItem(secondPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    secondPlanet.Spend(halfBudgetSecondPlanet);
                    secondPlanet.Profit(halfBudgetFirstPlanet);
                    secondPlanet.Profit(firstCalculatedValue);

                    planets.RemoveItem(firstPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            }

        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
