using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Queries.GetRooms
{
    public interface IGetRoomsHandler : IRequestHandler<GetRoomsQuery, BaseResult<GetRoomsResult>>
    {
    }
}