using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Commands.CancelBooking
{
    public class CancelBookingCommand : IRequest<BaseResult<CancelBookingResult>>
    {
    }
}