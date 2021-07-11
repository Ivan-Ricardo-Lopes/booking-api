using System.Collections.Generic;

namespace IRL.Bookings.Infra.DatabaseModels
{
    public class RoomDbModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BookingDbModel> Bookings { get; set; }
    }
}