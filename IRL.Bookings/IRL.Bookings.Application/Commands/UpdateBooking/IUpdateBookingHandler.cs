using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public interface IUpdateBookingHandler : IRequestHandler<UpdateBookingCommand, BaseResult<UpdateBookingResult>>
    {
    }
}