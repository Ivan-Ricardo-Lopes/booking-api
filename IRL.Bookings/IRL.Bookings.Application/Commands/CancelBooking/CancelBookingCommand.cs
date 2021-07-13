using IRL.Bookings.Application.Shared;
using MediatR;
using System;

namespace IRL.Bookings.Application.Commands.CancelBooking
{
    public class CancelBookingCommand : IRequest<BaseResult<CancelBookingResult>>
    {
        public Guid Id { get; set; }
    }
}