using FluentValidation;
using IRL.Bookings.Application.Commands.CreateBooking;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public class UpdateBookingValidator : AbstractValidator<IUpdateBookingCommand>
    {
        public UpdateBookingValidator()
        {
            Include(new CreateBookingValidator());
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}