using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<BaseResult<GetBookingsResult>>
    {
    }
}