using IRL.Booking.Application.Shared;
using MediatR;

namespace IRL.Booking.Application.Queries.GetBookings
{
    public interface IGetBookingsHandler : IRequestHandler<GetBookingsQuery, BaseResult<GetBookingsResult>>
    {
    }
}