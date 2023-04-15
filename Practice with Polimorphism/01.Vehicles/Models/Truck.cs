using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;
        protected Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, FuelConsumptionIncrement)
        {
        }

        public override void Refueled(double liters)
        {
            base.Refueled(liters * 0.95);
        }
    }
}
