using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public interface ICreateBookingHandler : IRequestHandler<CreateBookingCommand, BaseResult<CreateBookingResult>>
    {
    }
}