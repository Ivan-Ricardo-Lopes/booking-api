using FluentValidation;

namespace IRL.Bookings.Application.Commands.CancelBooking
{
    public class CancelBookingValidator : AbstractValidator<CancelBookingCommand>
    {
        public CancelBookingValidator()
        {
        }
    }
}