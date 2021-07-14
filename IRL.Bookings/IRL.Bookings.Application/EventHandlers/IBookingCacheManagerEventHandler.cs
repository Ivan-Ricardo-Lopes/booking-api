using IRL.Bookings.Application.Events;
using IRL.Bookings.Infra.Cache;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.EventHandlers
{
    public class IBookingCacheManagerEventHandler :
                            INotificationHandler<BookingCreated>,
                            INotificationHandler<BookingUpdated>,
                            INotificationHandler<BookingCanceled>
    {
        private readonly ILogger<IBookingCacheManagerEventHandler> _logger;
        private readonly ICache _cache;
        private readonly string _bookingsCacheKey;

        public IBookingCacheManagerEventHandler(ILogger<IBookingCacheManagerEventHandler> logger,
            ICache cache,
            IConfiguration configuration)
        {
            this._logger = logger;
            this._cache = cache;
            this._bookingsCacheKey = configuration.GetSection("bookingsCacheKey").ToString();
        }

        public Task Handle(BookingCreated notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"BookingCreated: { notification}");
                InvalidateCache();
            });
        }

        public Task Handle(BookingUpdated notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"BookingUpdated: { notification}");
                InvalidateCache();
            });
        }

        public Task Handle(BookingCanceled notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation($"BookingCanceled: { notification}");
                InvalidateCache();
            });
        }

        private void InvalidateCache()
        {
            _cache.Set(_bookingsCacheKey, null);
        }
    }
}