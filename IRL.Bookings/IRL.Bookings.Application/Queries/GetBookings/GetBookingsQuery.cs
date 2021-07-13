using IRL.Bookings.Application.Shared;
using MediatR;
using System;

namespace IRL.Bookings.Application.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<BaseResult<GetBookingsResult>>
    {
        public Guid RoomId { get; set; }
    }
}