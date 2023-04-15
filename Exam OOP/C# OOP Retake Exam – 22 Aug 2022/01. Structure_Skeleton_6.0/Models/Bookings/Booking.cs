using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }
        //The room where the Booking will be accomodated
        public IRoom Room { get; private set; }

        //o	ResidenceDuration must be greater than zero. If NOT, throw new ArgumentException with message: "Duration cannot be negative or zero!". -> ВАЛИДАЦИЯ
        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                residenceDuration = value;
            }

        }
        //The count of Adults cannot be less than 1. If so, throw new ArgumentException with message: "Adults count cannot be negative or zero!". -> ВАЛИДАЦИЯ
        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }
        }
        //o	The count of Children cannot be less than 0. If so, throw new ArgumentException with message: "Children count cannot be negative!". -> ВАЛИДАЦИЯ
        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                childrenCount = value;
            }
        }
        public int BookingNumber { get; private set; }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }

        private double TotalPaid()
            => Math.Round(ResidenceDuration * Room.PricePerNight, 2);
    }
}
