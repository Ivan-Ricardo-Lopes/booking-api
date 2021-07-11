using IRL.Bookings.Domain.Bookings.Entities;
using MediatR;
using System;

namespace IRL.Bookings.Application.Events
{
    public class BookingCreated : INotification
    {
        public Guid Id { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public Guid RoomId { get; private set; }

        public BookingCreated(Booking booking)
        {
            this.Id = booking.Id;
            this.FromDate = booking.FromDate;
            this.ToDate = booking.ToDate;
            this.RoomId = booking.RoomId;
        }
    }
}