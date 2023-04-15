using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;

        private double currentBill;
        private double turnover; 

        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();

            currentBill = 0;
            turnover = 0;
        }
        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu => delicacies;
        public IRepository<ICocktail> CocktailMenu => cocktails;
        public double CurrentBill => currentBill;
        public double Turnover => turnover;
        public bool IsReserved { get; private set; }
        public void UpdateCurrentBill(double amount)
        {
          currentBill += amount;

        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void ChangeStatus()
        {
            if (IsReserved)
            {
               IsReserved = false;
               return;
               
            }

            IsReserved = true;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var coctail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{coctail.ToString()}");
            }
            sb.AppendLine($"-Delicacy  menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
