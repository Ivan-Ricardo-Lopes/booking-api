using System;
using System.Collections.Generic;

namespace IRL.Bookings.Application.Queries.GetBookings
{
    public class GetBookingsResult
    {
        public List<BookingsResultItem> Bookings { get; set; } = new List<BookingsResultItem>();
    }

    public class BookingsResultItem
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Guid RoomId { get; set; }
    }
}