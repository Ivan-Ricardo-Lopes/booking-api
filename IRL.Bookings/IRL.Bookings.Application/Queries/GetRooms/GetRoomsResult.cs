using System;
using System.Collections.Generic;

namespace IRL.Bookings.Application.Queries.GetRooms
{
    public class GetRoomsResult
    {
        public List<RoomsResultItem> Rooms { get; set; } = new List<RoomsResultItem>();
    }

    public class RoomsResultItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}