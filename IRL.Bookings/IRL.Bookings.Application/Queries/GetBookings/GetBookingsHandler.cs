using AutoMapper;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Infra.Repositories;
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

        public GetBookingsHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
        }

        public async Task<BaseResult<GetBookingsResult>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _bookingRepository.GetAll();

            var result = new BaseResult<GetBookingsResult>();
            result.Payload.Bookings = _mapper.Map<List<BookingsResultItem>>(bookings.ToList());

            return result;
        }
    }
}