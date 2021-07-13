using FluentValidation;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public class CreateBookingValidator : AbstractValidator<ICreateBookingCommand>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.FromDate).NotEmpty();
            RuleFor(x => x.ToDate).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.ToDate)
                .GreaterThan(x => x.FromDate);
        }
    }
}