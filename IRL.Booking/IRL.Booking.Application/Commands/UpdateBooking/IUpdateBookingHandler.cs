using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Commands.UpdateBooking
{
    public interface IUpdateBookingHandler : IRequestHandler<UpdateBookingCommand, BaseResult<UpdateBookingResult>>
    {
    }
}