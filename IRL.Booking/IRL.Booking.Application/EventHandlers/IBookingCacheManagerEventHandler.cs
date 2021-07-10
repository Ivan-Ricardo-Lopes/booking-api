using IRL.Booking.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Booking.Application.EventHandlers
{
    public class IBookingCacheManagerEventHandler :
                            INotificationHandler<BookingCreated>,
                            INotificationHandler<BookingUpdated>,
                            INotificationHandler<BookingCanceled>
    {
        private readonly ILogger<IBookingCacheManagerEventHandler> _logger;

        public IBookingCacheManagerEventHandler(ILogger<IBookingCacheManagerEventHandler> logger)
        {
            this._logger = logger;
        }

        public Task Handle(BookingCreated notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"BookingCreated: { notification}");
            });
        }

        public Task Handle(BookingUpdated notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"BookingUpdated: { notification}");
            });
        }

        public Task Handle(BookingCanceled notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"BookingCanceled: { notification}");
            });
        }
    }
}