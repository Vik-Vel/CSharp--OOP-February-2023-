using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProba
{
    public class Truck : Vehicle
    {
        private const double AirConditioner = 1.6;
        protected Truck(double fuelQuantity, double fuelConsumptionPerKmInLiters) : base(fuelQuantity, fuelConsumptionPerKmInLiters, AirConditioner)
        {
        }

        public override void Refueled(double liters)
        {
            base.Refueled(liters * 0.95);
        }
    }
}
