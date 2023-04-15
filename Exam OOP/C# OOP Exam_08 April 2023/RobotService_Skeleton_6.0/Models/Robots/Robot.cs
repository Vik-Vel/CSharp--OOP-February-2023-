using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private List<int> interfaceStandards;
        public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            this.batteryLevel = batteryCapacity;
            this.convertionCapacityIndex = convertionCapacityIndex;
            this.interfaceStandards = new List<int>();
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNullOrWhitespace));
                }

                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BatteryCapacityBelowZero));
                }

                batteryCapacity = value;
            }
        }
        public int BatteryLevel => batteryLevel;

        public int ConvertionCapacityIndex => convertionCapacityIndex;

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandards;


        public void Eating(int minutes)
        {
            int totalCapacity = convertionCapacityIndex * minutes;
            if ( totalCapacity > BatteryCapacity - BatteryLevel )
            {
                batteryLevel = BatteryCapacity;
            }
            else
            {
                batteryLevel += totalCapacity;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            BatteryCapacity -= supplement.BatteryUsage;
            batteryLevel -= supplement.BatteryUsage;
            interfaceStandards.Add(supplement.InterfaceStandard);
            
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (consumedEnergy <= batteryLevel)
            {
                batteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append($"--Supplements installed: ");
            if (InterfaceStandards.Any())
            {
                sb.Append(string.Join(" ", InterfaceStandards));
            }
            else
            {
                sb.Append("none");
            }
           
            return sb.ToString().TrimEnd();
        }
    }
}
