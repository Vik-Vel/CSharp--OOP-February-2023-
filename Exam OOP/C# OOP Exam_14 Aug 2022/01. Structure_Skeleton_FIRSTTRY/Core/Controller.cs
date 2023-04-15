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
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (planets.FindByName(name) != default)
            {
                return string.Format(OutputMessages.ExistingPlanet,name);
            }
            else
            {
                planets.AddItem(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }
        //Creates a MilitaryUnit from the given type and adds it to the Army of the Planet with the given name. Every unit is unique. A Planet can have only one MilitaryUnit from a specific type:
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            //o	If a Planet with the given name doesn’t exist in the PlanetReposotiry, throw an InvalidOperationException with the following message: "Planet {planetName} does not exist!"
            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            //o	If the MilitaryUnit is not available in our application (no such type of MilitaryUnit exists in the child classes), throw an InvalidOperationException with the following message: "{unitTypeName} still not available!"
            if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            //o	If the same MilitaryUnit is already added, throw an InvalidOperationException with the following message: "{unitTypeName} already added to the Army of {planetName}!"
            if (planet.Army.Any(x=>x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            //o	If the MilitaryUnit is valid, add it to the UnitRepository of the planet. Planet’s Budget is reduced with the price of the unit and the following message is returned: "{unitTypeName} added successfully to the Army of {planetName}!"
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

            //o	If a Planet with the given name doesn’t exist in the PlanetReposotiry, throw an InvalidOperationException with the following message: "Planet {planetName} does not exist!"
            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            //o	If the same MilitaryUnit is already added, throw an InvalidOperationException with the following message: "{unitTypeName} already added to the Army of {planetName}!"
            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, weaponTypeName, planetName));
            }

            //o	If the Weapon is not available in our application (no such type of Weapon exists in the child classes), throw an InvalidOperationException with the following message: "{weaponTypeName} still not available!"
            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            // If the Weapon is valid, add it to the WeaponRepository of the planet. Planet’s Budget is reduced with the price of the weapon and the following message is returned: "{planetName} purchased {weaponTypeName}!"
            IWeapon weapon;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            //o	If a Planet with the given name doesn’t exist, throw an InvalidOperationException with the following message: "Planet {planetName} does not exist!" 
            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            //o	If there are no Military units added still, throw an InvalidOperationException with the following message: "No units available for upgrade!"
            else if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }
            //o	If the action is completed successfully, reduce the Budget by 1.25 billion QUID, train the army of the given Planet and return the following message: "{planetName} has upgraded its forces!".
            else
            {
                double specCost = 1.25;
                planet.TrainArmy();
                planet.Spend(specCost);

            }

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            double firstPlanetHalfBudget = firstPlanet.Budget / 2;
            double secondPlanetHalfBudget = secondPlanet.Budget / 2;

            double firstCalculateValue = firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(y => y.Price);

            double secondCalculateValue = secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(y => y.Price);

            double firstPowerRatio = firstPlanet.MilitaryPower;
            double secondPowerRatio = secondPlanet.MilitaryPower;

            bool firstHasNuclear = firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));

            bool secondHasNuclear = secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));

            var firstNuclear = firstPlanet.Weapons.FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

            var secondNuclear = secondPlanet.Weapons.FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

            if (firstPowerRatio > secondPowerRatio)
            {
                firstPlanet.Spend(firstPlanetHalfBudget);
                firstPlanet.Profit(secondPlanetHalfBudget);
                firstPlanet.Profit(secondCalculateValue);

                planets.RemoveItem(secondPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (secondPowerRatio > firstPowerRatio)
            {
                secondPlanet.Spend(secondPlanetHalfBudget);
                secondPlanet.Profit(firstPlanetHalfBudget);
                secondPlanet.Profit(firstCalculateValue);

                planets.RemoveItem(firstPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else
            {
                if (firstNuclear != null && secondNuclear != null)
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
                else if (firstNuclear != null)
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    firstPlanet.Profit(secondPlanetHalfBudget);
                    firstPlanet.Profit(secondCalculateValue);

                    planets.RemoveItem(secondPlanet.Name);

                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if( secondNuclear != null)
                {

                    secondPlanet.Spend(secondPlanetHalfBudget);
                    secondPlanet.Profit(firstPlanetHalfBudget);
                    secondPlanet.Profit(firstCalculateValue);

                    planets.RemoveItem(firstPlanet.Name);

                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
            }

        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
