using IRL.Bookings.Domain.Bookings.Entities;
using System;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public class CreateBookingResult
    {
        public Guid Id { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public Guid RoomId { get; private set; }

        public CreateBookingResult()
        {
        }

        public CreateBookingResult(Booking booking)
        {
            this.Id = booking.Id;
            this.FromDate = booking.FromDate;
            this.ToDate = booking.ToDate;
            this.RoomId = booking.RoomId;
        }
    }
}