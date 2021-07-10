using AutoMapper;
using IRL.Booking.Application.Shared;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Booking.Application.Queries.GetBookings
{
    public class GetBookingsHandler : IGetBookingsHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetBookingsHandler> _logger;

        public GetBookingsHandler(IMapper mapper, ILogger<GetBookingsHandler> logger)
        {
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<BaseResult<GetBookingsResult>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetBookings requested.");
            var result = new BaseResult<GetBookingsResult>();
            return result;
        }
    }
}