using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<BaseResult<GetBookingsResult>>
    {
    }
}