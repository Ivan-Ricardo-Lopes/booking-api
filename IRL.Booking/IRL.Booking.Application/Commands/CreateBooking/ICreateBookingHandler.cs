using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Commands.CreateBooking
{
    public interface ICreateBookingHandler : IRequestHandler<CreateBookingCommand, BaseResult<CreateBookingResult>>
    {
    }
}