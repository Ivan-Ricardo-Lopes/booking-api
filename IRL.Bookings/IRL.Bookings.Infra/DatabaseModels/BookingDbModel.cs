using System;

namespace IRL.Bookings.Infra.DatabaseModels
{
    public class BookingDbModel
    {
        public string Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CustomerName { get; set; }
        public string RoomId { get; set; }
    }
}