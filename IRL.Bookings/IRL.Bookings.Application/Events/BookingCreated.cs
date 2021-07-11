using IRL.Bookings.Domain.Bookings.Entities;
using MediatR;

namespace IRL.Bookings.Application.Events
{
    public class BookingCreated : INotification
    {
        public BookingCreated(Booking booking)
        {
        }
    }
}