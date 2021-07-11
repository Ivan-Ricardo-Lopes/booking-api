using AutoMapper;
using IRL.Bookings.Application.Commands.CancelBooking;
using IRL.Bookings.Application.Commands.CreateBooking;
using IRL.Bookings.Application.Commands.UpdateBooking;
using IRL.Bookings.Application.Queries.GetBookings;
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
        public async Task<IActionResult> Get([FromQuery] GetBookingsQuery model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(model, cancellationToken);

            if (output.IsValid)
            {
                return Ok(output.Payload);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateBookingResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromQuery] CreateBookingCommand model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(model, cancellationToken);

            if (output.IsValid)
            {
                return Ok(output.Payload);
            }

            return BadRequest(new { errors = output.Errors });
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBookingResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromQuery] UpdateBookingCommand model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(_mapper.Map<UpdateBookingCommand>(model), cancellationToken);

            if (output.IsValid)
            {
                return Ok(output.Payload);
            }

            return BadRequest(output.Payload);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelBookingResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cancel([FromQuery] CancelBookingCommand model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(model, cancellationToken);

            if (output.IsValid)
            {
                return Ok(output.Payload);
            }

            return BadRequest(output.Errors);
        }
    }
}