using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<BaseResult<UpdateBookingResult>>
    {
    }
}