using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel;
        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            enduranceLevel = 1;
        }
        public double Cost { get; private set; }

        public int EnduranceLevel => enduranceLevel;
    
        public void IncreaseEndurance()
        {
            if (enduranceLevel == 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }

            enduranceLevel++;
        }
    }
}
