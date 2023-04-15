using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            //Booth constructor will be expecting as first parameter boothId.So it should be created by taking the count of the already added booths in the BoothRepository + 1.
            int boothId = booths.Models.Count + 1;

            Booth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            



        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            throw new NotImplementedException();
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }
    }
}
