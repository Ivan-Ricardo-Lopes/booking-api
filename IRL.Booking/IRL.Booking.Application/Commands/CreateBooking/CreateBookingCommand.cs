using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<BaseResult<CreateBookingResult>>
    {
    }
}