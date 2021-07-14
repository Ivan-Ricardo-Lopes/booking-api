using FluentValidation;
using IRL.Bookings.Infra.Repositories;
using System;
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
                .GreaterThan(x => x.FromDate);

            RuleFor(x => x.RoomId)
                .NotEmpty()
                .MustAsync(async (roomId, cancellation) =>
            (await RoomExists(roomId.ToString())))
                .WithMessage("Room not found.")
                .MustAsync(async (booking, roomId, cancellation) =>
                (await RoomIsAvailable(roomId.ToString(), booking.FromDate, booking.ToDate)))
                .WithMessage("This room is unavailable on this date");

            
        }

        private async Task<bool> RoomIsAvailable(string roomId, DateTime fromDate, DateTime toDate)
        {
            return await _bookingRepository.ExistsBetweenDates(roomId, fromDate, toDate);
        }

        private async Task<bool> RoomExists(string roomId)
        {
            return await _roomRepository.Exists(roomId);
        }

    }
}