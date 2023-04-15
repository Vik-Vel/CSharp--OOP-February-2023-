using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    internal class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;
        public IReadOnlyCollection<ISupplement> Models() => supplements;

        public void AddNew(ISupplement model) => supplements.Add(model);

        public bool RemoveByName(string typeName) =>
            supplements.Remove(supplements.FirstOrDefault(x => x.GetType().Name == typeName));



        public ISupplement FindByStandard(int interfaceStandard)
        {
            var finding = supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
            if (finding != default)
            {
                return finding;
            }
            return null;
        }
    }
}
