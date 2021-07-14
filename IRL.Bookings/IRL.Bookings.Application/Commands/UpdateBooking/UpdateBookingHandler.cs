using AutoMapper;
using IRL.Bookings.Application.Events;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Domain.Bookings.Entities;
using IRL.Bookings.Infra.DatabaseModels;
using IRL.Bookings.Infra.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public class UpdateBookingHandler : IUpdateBookingHandler
    {
        private readonly UpdateBookingValidator _validator;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public UpdateBookingHandler(UpdateBookingValidator validator,
            IMediator mediator,
            IMapper mapper,
            IBookingRepository bookingRepository,
            IRoomRepository roomRepository)
        {
            this._validator = validator;
            this._mediator = mediator;
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
            this._roomRepository = roomRepository;
        }

        public async Task<BaseResult<UpdateBookingResult>> Handle(UpdateBookingCommand command, CancellationToken cancellationToken)
        {
            var output = new BaseResult<UpdateBookingResult>();
            output.AddErrors(_validator.Validate(command));

            if (!output.IsValid)
                return output;

            var bookingDbModel = await _bookingRepository.GetById(command.Id.ToString());

            if (bookingDbModel == null)
            {
                output.AddError("Id", $"Booking not found. id: {command.Id}");
                return output;
            }

            var booking = _mapper.Map<Booking>(bookingDbModel);

            if (!booking.Valid)
            {
                output.AddErrors(booking.ValidationResult);
                return output;
            }

            bookingDbModel = _mapper.Map<BookingDbModel>(booking);
            await _bookingRepository.Update(bookingDbModel);
            await _bookingRepository.SaveChanges();

            await _mediator.Publish(new BookingUpdated(booking));
            return output;
        }
    }
}