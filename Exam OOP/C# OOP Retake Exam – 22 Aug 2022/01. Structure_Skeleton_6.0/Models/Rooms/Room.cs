using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        //o	Set PricePerNight initial value to zero. Ние я инициализираме тук, следователно е 0

        private double pricePerNight;

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity { get; private set; }

        //PricePerNight cannot be negative. If so, throw new ArgumentException with message : "Price cannot be negative!". 
        //Set PricePerNight initial value to zero.
        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value;
            }
        }

        //This method sets the PricePerNight value when needed.
        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
