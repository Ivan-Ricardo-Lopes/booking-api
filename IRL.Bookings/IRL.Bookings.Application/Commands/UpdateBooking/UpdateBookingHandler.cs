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

            #region input fail fast validation

            var inputValidationResult = _validator.Validate(command);
            output.AddErrors(inputValidationResult);

            if(command.RoomId != null)
            {
                if (!await _roomRepository.Exists(command.RoomId.ToString()))
                    output.AddError("RoomId", $"Room not found. id: {command.RoomId}");
            }
            

            var bookingDbModel = await _bookingRepository.GetById(command.Id.ToString());

            if (bookingDbModel == null)
                output.AddError("Id", $"Booking not found. id: {command.Id}");

            if (!output.IsValid)
                return output;

            #endregion input fail fast validation

            #region domain validation

            if (await _bookingRepository.ExistsBetweenDates(command.RoomId.ToString(), command.FromDate, command.ToDate))
                output.AddError("RoomId", "This room is unavailable on this date");

            var booking = _mapper.Map<Booking>(bookingDbModel);

            output.AddErrors(booking.ValidationResult);

            if (!output.IsValid)
                return output;

            #endregion domain validation

            bookingDbModel = _mapper.Map<BookingDbModel>(booking);
            await _bookingRepository.Update(bookingDbModel);
            await _bookingRepository.SaveChanges();

            await _mediator.Publish(new BookingUpdated(booking));
            return output;
        }
    }
}