using FluentValidation;

namespace IRL.Booking.Application.Commands.CancelBooking
{
    public class CancelBookingValidator : AbstractValidator<CancelBookingCommand>
    {
        public CancelBookingValidator()
        {
        }
    }
}