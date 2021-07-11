using System;
using System.ComponentModel.DataAnnotations;

namespace IRL.Booking.API.Transport.Bookings.Create
{
    public class CreateBookingModel
    {
        [Required]
        public Guid RoomId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }
    }
}