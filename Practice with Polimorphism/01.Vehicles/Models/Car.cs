using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionIncrement = 0.9;
        protected Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, FuelConsumptionIncrement)
        {
        }
    }
}
