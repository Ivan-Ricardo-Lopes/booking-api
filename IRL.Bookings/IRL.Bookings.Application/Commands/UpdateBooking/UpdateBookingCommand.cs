using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<BaseResult<UpdateBookingResult>>
    {
    }
}