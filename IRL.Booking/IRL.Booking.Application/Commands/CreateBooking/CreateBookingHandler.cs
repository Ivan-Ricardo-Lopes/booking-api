using IRL.Booking.Application.Events;
using IRL.Booking.Application.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Booking.Application.Commands.CreateBooking
{
    public class CreateBookingHandler : ICreateBookingHandler
    {
        private readonly CreateBookingValidator _validator;
        private readonly ILogger<CreateBookingHandler> _logger;
        private readonly IMediator _mediator;

        public CreateBookingHandler(CreateBookingValidator validator,
            ILogger<CreateBookingHandler> logger,
            IMediator mediator)
        {
            this._validator = validator;
            this._logger = logger;
            this._mediator = mediator;
            ;
        }

        public async Task<BaseResult<CreateBookingResult>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreatedBooking request: {command}");
            var result = new BaseResult<CreateBookingResult>();
            await _mediator.Publish(new BookingCreated());
            return result;
        }
    }
}