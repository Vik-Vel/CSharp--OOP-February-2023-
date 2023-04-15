using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Exceptions;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Vehicle: IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double fuelConsumptionIncrement)
        {
            FuelQuantity = fuelQuantity;
            fuelConsumption = fuelConsumption + fuelConsumptionIncrement;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumptionForLiterPerKm { get; private set; }
        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionForLiterPerKm;
            if (neededFuel > FuelQuantity)
            {
                //Not enough fuel
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelExceptionMessage,
                    this.GetType().Name));
            }

            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refueled(double liters)
        {
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
