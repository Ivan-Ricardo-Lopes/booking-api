using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Queries.GetBookings
{
    public interface IGetBookingsHandler : IRequestHandler<GetBookingsQuery, BaseResult<GetBookingsResult>>
    {
    }
}