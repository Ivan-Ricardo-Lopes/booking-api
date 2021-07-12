using IRL.Bookings.Application.Shared;
using MediatR;

namespace IRL.Bookings.Application.Queries.GetRooms
{
    public class GetRoomsQuery : IRequest<BaseResult<GetRoomsResult>>
    {
    }
}