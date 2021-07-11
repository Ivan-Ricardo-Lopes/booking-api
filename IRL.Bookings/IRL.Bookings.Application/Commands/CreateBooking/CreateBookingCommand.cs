using IRL.Bookings.Application.Shared;
using MediatR;
using System;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<BaseResult<CreateBookingResult>>
    {
        public Guid RoomId { get; set; }
        public string CustomerName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}