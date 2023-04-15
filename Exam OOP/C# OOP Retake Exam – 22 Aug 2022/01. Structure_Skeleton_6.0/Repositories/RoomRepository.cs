using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        //•	Adds new Room to the repository.
        public void AddNew(IRoom model)
        => rooms.Add(model);

        //•	Returns a Room which is entity of type with the given room type name
        public IRoom Select(string criteria)
            => rooms.FirstOrDefault(r => r.GetType().Name == criteria);

        //•	Returns a ReadonlyCollection of all rooms, that have been added to the repository.
        public IReadOnlyCollection<IRoom> All()
            => rooms.AsReadOnly();
    }
}
