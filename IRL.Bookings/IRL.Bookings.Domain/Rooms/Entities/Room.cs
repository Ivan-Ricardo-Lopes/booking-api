using IRL.Bookings.Domain.Shared;

namespace IRL.Bookings.Domain.Rooms.Entities
{
    public class Room : Entity, IEntity
    {
        public string Name { get; set; }
    }
}