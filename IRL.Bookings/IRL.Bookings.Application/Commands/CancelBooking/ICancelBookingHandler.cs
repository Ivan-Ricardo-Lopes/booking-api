using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Commands.CancelBooking
{
    public interface ICancelBookingHandler : IRequestHandler<CancelBookingCommand, BaseResult<CancelBookingResult>>
    {
    }
}