using IRL.Bookings.Application.Shared;
using MediatR;
using System;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<BaseResult<UpdateBookingResult>>
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string CustomerName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}