using FluentValidation;
using IRL.Bookings.Domain.Bookings.Entities;

namespace IRL.Bookings.Domain.Bookings.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
        }
    }
}