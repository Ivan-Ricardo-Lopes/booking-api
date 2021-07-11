using IRL.Bookings.Application.Events;
using IRL.Bookings.Application.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Commands.CancelBooking
{
    public class CancelBookingHandler : ICancelBookingHandler
    {
        private readonly CancelBookingValidator _validator;
        private readonly ILogger<CancelBookingHandler> _logger;
        private readonly IMediator _mediator;

        public CancelBookingHandler(CancelBookingValidator validator,
            ILogger<CancelBookingHandler> logger,
            IMediator mediator)
        {
            this._validator = validator;
            this._logger = logger;
            this._mediator = mediator;
            ;
        }

        public async Task<BaseResult<CancelBookingResult>> Handle(CancelBookingCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CancelBooking request: {command}");
            var result = new BaseResult<CancelBookingResult>();
            await _mediator.Publish(new BookingCanceled());
            return result;
        }
    }
}