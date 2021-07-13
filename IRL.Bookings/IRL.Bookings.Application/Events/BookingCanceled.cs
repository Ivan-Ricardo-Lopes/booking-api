using MediatR;
using System;

namespace IRL.Bookings.Application.Events
{
    public class BookingCanceled : INotification
    {
        public Guid Id { get; private set; }
        public Guid RoomId { get; private set; }
    }
}