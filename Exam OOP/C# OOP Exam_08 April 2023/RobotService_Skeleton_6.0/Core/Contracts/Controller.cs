using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Suplements;
using RobotService.Models.Supplements;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
            
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if(typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated,typeName);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName,model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);


        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            //Find the first ISupplement with the given supplementTypeName in the SupplementRepository 
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            //Select only the robots, from the given model 
            var selectedModels = robots.Models().Where(r => r.Model == model);
            //We are looking for non-upgraded robots
            var stillNotUpgraded =
                selectedModels.Where(r => r.InterfaceStandards.All(s => s != supplement.InterfaceStandard));
            //Collection for not upgraded robots
            var robotForUpgrade = stillNotUpgraded.FirstOrDefault();

            if (robotForUpgrade == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            //If there are still not upgraded robots, take the first IRobot from the previous selected robots and use the built-in InstallSupplement() method to upgrade the robot with the new supplement.
            robotForUpgrade.InstallSupplement(supplement);
            //o	Remove the ISupplement from the SupplementRepository.
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string RobotRecovery(string model, int minutes)
        {
            var selectedRobots = robots.Models().Where(r => r.Model == model && r.BatteryLevel * 2 < r.BatteryCapacity);
            int robotsFeed = 0;
            foreach (var robot in selectedRobots)
            {
                robot.Eating(minutes);
                robotsFeed++;
            }

            return string.Format(OutputMessages.RobotsFed, robotsFeed);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            //Select the robots, supporting the given interfaceStandard from the RobotRepository (check if every robot’s InterfaceStandards collection contains the given interfaceStandard)
            var selectedRobots = robots.Models().Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard))
                .OrderByDescending(y => y.BatteryLevel);

            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform,intefaceStandard);
            }

            int powerSum = selectedRobots.Sum(x => x.BatteryLevel);

            if (powerSum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - powerSum);
            }

            int usedRobotsCount = 0;
            foreach (var robot in selectedRobots)
            {
                usedRobotsCount++;
                if (totalPowerNeeded <= robot.BatteryLevel)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }

            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var sorted = robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(x => x.BatteryCapacity);

            foreach (var robot in sorted)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
