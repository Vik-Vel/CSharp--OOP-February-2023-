using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProba
{
    public class Car : Vehicle
    {
        private const double AirConditioner = 0.9;
        protected Car(double fuelQuantity, double fuelConsumptionPerKmInLiters) : base(fuelQuantity, fuelConsumptionPerKmInLiters, AirConditioner)
        {

        }

        
        

    }
}
