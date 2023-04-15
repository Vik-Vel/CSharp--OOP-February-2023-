using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProba
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKmInLiters { get; }

        //Тъй като ще връщаме стринг дали е успял да мине или не за това е стринг
        string DrivenDistance(double distance);

        //Камиона и колата имат различно пълнене
        void Refueled(double liters);


    }
}
