using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Commands.CancelBooking
{
    public interface ICancelBookingHandler : IRequestHandler<CancelBookingCommand, BaseResult<CancelBookingResult>>
    {
    }
}