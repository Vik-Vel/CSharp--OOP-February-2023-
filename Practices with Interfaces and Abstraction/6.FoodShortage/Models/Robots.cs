using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Robots : IIdentificable
    {
        public Robots(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; }
        public string Id { get; }
    }
}
