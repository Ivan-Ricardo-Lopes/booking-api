using AutoMapper;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Infra.Cache;
using IRL.Bookings.Infra.DatabaseModels;
using IRL.Bookings.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Queries.GetBookings
{
    public class GetBookingsHandler : IGetBookingsHandler
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly ICache _cache;
        private readonly string _bookingsCacheKey;

        public GetBookingsHandler(IMapper mapper,
            IBookingRepository bookingRepository,
            ICache cache,
            IConfiguration configuration)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
            this._cache = cache;
            this._bookingsCacheKey = configuration.GetSection("bookingsCacheKey").ToString();

        }

        public async Task<BaseResult<GetBookingsResult>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = new BaseResult<GetBookingsResult>();

            var bookings = _cache.Get<IEnumerable<BookingDbModel>>(_bookingsCacheKey);

            if (bookings == null)
            {
                bookings = await _bookingRepository.GetAll();
                _cache.Set(_bookingsCacheKey, bookings);
            }                

            result.Payload.Bookings = _mapper.Map<List<BookingsResultItem>>(bookings.ToList());

            return result;
        }
    }
}