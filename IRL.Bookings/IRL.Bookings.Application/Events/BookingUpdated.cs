using IRL.Bookings.Domain.Bookings.Entities;
using MediatR;

namespace IRL.Bookings.Application.Events
{
    public class BookingUpdated : INotification
    {
        public BookingUpdated(Booking booking)
        {
        }
    }
}