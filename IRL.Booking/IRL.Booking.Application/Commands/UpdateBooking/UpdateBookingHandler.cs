using IRL.Booking.Application.Events;
using IRL.Booking.Application.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Booking.Application.Commands.UpdateBooking
{
    public class UpdateBookingHandler : IUpdateBookingHandler
    {
        private readonly UpdateBookingValidator _validator;
        private readonly ILogger<UpdateBookingHandler> _logger;
        private readonly IMediator _mediator;

        public UpdateBookingHandler(UpdateBookingValidator validator,
            ILogger<UpdateBookingHandler> logger,
            IMediator mediator)
        {
            this._validator = validator;
            this._logger = logger;
            this._mediator = mediator;
            ;
        }

        public async Task<BaseResult<UpdateBookingResult>> Handle(UpdateBookingCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UpdateBooking request: {command}");
            var result = new BaseResult<UpdateBookingResult>();
            await _mediator.Publish(new BookingUpdated());
            return result;
        }
    }
}