using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Commands.CancelBooking
{
    public class CancelBookingCommand : IRequest<BaseResult<CancelBookingResult>>
    {
    }
}