using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Models.Suplements;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private  List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public IReadOnlyCollection<IRobot> Models() => robots.AsReadOnly();

        public void AddNew(IRobot model) => robots.Add(model);

        public bool RemoveByName(string typeName)
        {
            IRobot removedElem = robots.FirstOrDefault(x => x.GetType().Name == typeName);
            if (removedElem != default)
            {
                robots.Remove(removedElem);
                return true;
            }
            return false;
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            var finding = robots.FirstOrDefault(x => x.ConvertionCapacityIndex == interfaceStandard);

            if (finding != default)
            {
                return finding;
            }
            return null;  
        }
    }
}
