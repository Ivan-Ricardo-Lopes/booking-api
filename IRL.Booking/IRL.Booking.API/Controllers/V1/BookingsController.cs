using AutoMapper;
using IRL.Booking.API.Transport.Bookings.Cancel;
using IRL.Booking.API.Transport.Bookings.Create;
using IRL.Booking.API.Transport.Bookings.GetAll;
using IRL.Booking.API.Transport.Bookings.Update;
using IRL.Booking.Application.Commands.CancelBooking;
using IRL.Booking.Application.Commands.CreateBooking;
using IRL.Booking.Application.Commands.UpdateBooking;
using IRL.Booking.Application.Queries.GetBookings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

using System.Threading.Tasks;

namespace IRL.Booking.API.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookingsController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all bookings.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>All bookings.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookingsResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetAllBookingModel model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(_mapper.Map<GetBookingsQuery>(model), cancellationToken);

            if (output.IsSuccess)
            {
                var response = _mapper.Map<GetAllBookingResponse>(output.Payload);

                return Ok(response);
            }

            return BadRequest(output.Errors);
        }

        /// <summary>
        /// Create booking.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>Booking confirmation.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateBookingResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromQuery] CreateBookingModel model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(_mapper.Map<CreateBookingCommand>(model), cancellationToken);

            if (output.IsSuccess)
            {
                var response = _mapper.Map<CreateBookingResponse>(output.Payload);

                return Ok(response);
            }

            return BadRequest(output.Errors);
        }

        /// <summary>
        /// Update booking.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>Update confirmation.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBookingResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromQuery] UpdateBookingModel model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(_mapper.Map<UpdateBookingCommand>(model), cancellationToken);

            if (output.IsSuccess)
            {
                var response = _mapper.Map<UpdateBookingResponse>(output.Payload);

                return Ok(response);
            }

            return BadRequest(output.Errors);
        }

        /// <summary>
        /// Cancel booking.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>Cancel confirmation.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelBookingResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cancel([FromQuery] CancelBookingModel model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(_mapper.Map<CancelBookingCommand>(model), cancellationToken);

            if (output.IsSuccess)
            {
                var response = _mapper.Map<CancelBookingResponse>(output.Payload);

                return Ok(response);
            }

            return BadRequest(output.Errors);
        }
    }
}