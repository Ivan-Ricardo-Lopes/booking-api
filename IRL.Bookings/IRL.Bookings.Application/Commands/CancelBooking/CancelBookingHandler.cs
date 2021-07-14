using IRL.Bookings.Application.Events;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Infra.Repositories;
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
        private readonly IBookingRepository _bookingRepository;

        public CancelBookingHandler(CancelBookingValidator validator,
            ILogger<CancelBookingHandler> logger,
            IMediator mediator,
            IBookingRepository bookingRepository)
        {
            this._validator = validator;
            this._logger = logger;
            this._mediator = mediator;
            this._bookingRepository = bookingRepository;
            ;
        }

        public async Task<BaseResult<CancelBookingResult>> Handle(CancelBookingCommand command, CancellationToken cancellationToken)
        {
            var output = new BaseResult<CancelBookingResult>();
            output.AddErrors(_validator.Validate(command));
            if (!output.IsValid)
                return output;

            var booking = await _bookingRepository.GetById(command.Id.ToString());

            if(booking == null)
            {
                output.AddError("Id", "Booking not found");
                return output;
            }

            await _bookingRepository.Delete(booking);
            await _bookingRepository.SaveChanges();

            await _mediator.Publish(new BookingCanceled());
            return output;
        }
    }
}