using AutoMapper;
using IRL.Bookings.Application.Events;
using IRL.Bookings.Application.Shared;
using IRL.Bookings.Domain.Bookings.Entities;
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
        }

        public async Task<BaseResult<CreateBookingResult>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var output = new BaseResult<CreateBookingResult>();
            output.AddErrors(_validator.Validate(command));

            if (!output.IsValid)
                return output;

            var booking = new Booking(Guid.NewGuid(), command.FromDate, command.ToDate, command.RoomId, command.CustomerName);

            if (!booking.Valid)
            {
                output.AddErrors(booking.ValidationResult);
                return output;
            }

            await _bookingRepository.Add(_mapper.Map<BookingDbModel>(booking));
            await _bookingRepository.SaveChanges();

            await _mediator.Publish(new BookingCreated(booking));
            output.Payload = new CreateBookingResult(booking);
            return output;
        }
    }
}