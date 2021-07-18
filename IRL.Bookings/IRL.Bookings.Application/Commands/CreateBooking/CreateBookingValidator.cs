using FluentValidation;
using IRL.Bookings.Infra.Repositories;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public class CreateBookingValidator : AbstractValidator<ICreateBookingCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingValidator(IRoomRepository roomRepository,
            IBookingRepository bookingRepository)
        {
            this._bookingRepository = bookingRepository;
            this._roomRepository = roomRepository;

            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.FromDate).NotEmpty();
            RuleFor(x => x.ToDate)
                .NotEmpty()
                .GreaterThan(x => x.FromDate.Date);

            RuleFor(x => x.RoomId)
                .NotEmpty()
                .MustAsync(async (roomId, cancellation) =>
            (await RoomExists(roomId.ToString())))
                .WithMessage("Room not found.");
        }

        private async Task<bool> RoomExists(string roomId)
        {
            return await _roomRepository.Exists(roomId);
        }
    }
}