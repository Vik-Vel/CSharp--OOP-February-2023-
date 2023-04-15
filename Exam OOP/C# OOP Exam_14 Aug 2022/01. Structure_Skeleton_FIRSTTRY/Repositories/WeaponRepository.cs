using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons;

        //•	Adds new weapon to the repository.
        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }
        //•	Returns a weapon with the given  type name, if it exists. If it doesn't, returns null.
        //
        public IWeapon FindByName(string name) => weapons.FirstOrDefault(x => x.GetType().Name == name);

        //•	Removes a weapon with the given typeName from the collection. Returns true if the deletion was sucessful. Otherwise returns false.
        public bool RemoveItem(string name) => weapons.Remove(weapons.FirstOrDefault(x=>x.GetType().Name == name));
        
    }
}
