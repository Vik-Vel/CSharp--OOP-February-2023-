using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProba.Exceptions;

namespace VehicleProba
{
    public class Vehicle : IVehicle
    {
        
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKmInLiters, double increasedFuel)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKmInLiters = fuelConsumptionPerKmInLiters + increasedFuel;
        }
        public double FuelQuantity { get; private set;}
        public double FuelConsumptionPerKmInLiters { get; private set}
        public  string DrivenDistance(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKmInLiters;

            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InsufficientFuelExceptionMessage,
                    this.GetType().Name));
            }

            FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }
        //Truck has different refuel logic =>
        //We make the method virtual and Truck will override it (Run-Time Polymorphism)
        public virtual void Refueled(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
