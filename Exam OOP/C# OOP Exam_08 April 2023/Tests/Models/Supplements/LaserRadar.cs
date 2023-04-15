using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Suplements;

namespace RobotService.Models.Supplements
{
    public class LaserRadar : Supplement
    {
        private const int InterfaceStandard = 20082;
        private const int BatteryUsage = 5000;
        public LaserRadar() : base(InterfaceStandard, BatteryUsage)
        {
        }
    }
}
