using FluentValidation;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public class UpdateBookingValidator : AbstractValidator<UpdateBookingCommand>
    {
        public UpdateBookingValidator()
        {
        }
    }
}