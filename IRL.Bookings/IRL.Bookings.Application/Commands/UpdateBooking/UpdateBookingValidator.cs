using FluentValidation;
using IRL.Bookings.Application.Commands.CreateBooking;
using IRL.Bookings.Infra.Repositories;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public class UpdateBookingValidator : AbstractValidator<IUpdateBookingCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public UpdateBookingValidator(IRoomRepository roomRepository,
            IBookingRepository bookingRepository)
        {
            this._bookingRepository = bookingRepository;
            this._roomRepository = roomRepository;

            Include(new CreateBookingValidator(_roomRepository, _bookingRepository));
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}