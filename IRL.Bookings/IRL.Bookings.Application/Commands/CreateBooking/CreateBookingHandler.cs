using AutoMapper;
using IRL.Bookings.Application.Events;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Domain.Bookings.Entities;
using IRL.Bookings.Domain.Bookings.ValueObjects;
using IRL.Bookings.Infra.DatabaseModels;
using IRL.Bookings.Infra.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public class CreateBookingHandler : ICreateBookingHandler
    {
        private readonly CreateBookingValidator _validator;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public CreateBookingHandler(CreateBookingValidator validator,
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
            ;
        }

        public async Task<BaseResult<CreateBookingResult>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var output = new BaseResult<CreateBookingResult>();

            #region input fail fast validation

            var inputValidationResult = _validator.Validate(command);
            output.AddErrors(inputValidationResult);

            if (!await _roomRepository.Exists(command.RoomId.ToString()))
                output.AddError("RoomId", $"Room not found. id: {command.RoomId}");

            if (!output.IsValid)
                return output;

            #endregion input fail fast validation

            #region domain validation

            if (await _bookingRepository.ExistsBetweenDates(command.RoomId.ToString(), command.FromDate, command.ToDate))
                output.AddError("RoomId", "This room is unavailable on this date");

            var booking = new Booking(Guid.NewGuid(), command.FromDate, command.ToDate, command.RoomId, new CustomerInfo(command.CustomerName));
            output.AddErrors(booking.ValidationResult);

            if (!output.IsValid)
                return output;

            #endregion domain validation

            await _bookingRepository.Add(_mapper.Map<BookingDbModel>(booking));
            await _bookingRepository.SaveChanges();

            await _mediator.Publish(new BookingCreated(booking));
            output.Payload = new CreateBookingResult(booking);
            return output;
        }
    }
}