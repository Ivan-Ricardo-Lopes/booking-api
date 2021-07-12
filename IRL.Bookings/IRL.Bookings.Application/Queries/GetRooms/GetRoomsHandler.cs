using AutoMapper;
using IRL.Bookings.Application.Queries.GetRooms;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Queries.GetBookings
{
    public class GetRoomsHandler : IGetRoomsHandler
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public GetRoomsHandler(IMapper mapper, IRoomRepository RoomRepository)
        {
            this._mapper = mapper;
            this._roomRepository = RoomRepository;
        }

        public async Task<BaseResult<GetRoomsResult>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var Rooms = await _roomRepository.GetAll();

            var result = new BaseResult<GetRoomsResult>();
            result.Payload.Rooms = _mapper.Map<List<RoomsResultItem>>(Rooms.ToList());

            return result;
        }
    }
}