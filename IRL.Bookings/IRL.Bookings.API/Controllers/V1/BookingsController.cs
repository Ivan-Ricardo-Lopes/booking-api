using AutoMapper;
using IRL.Bookings.Application.Commands.CancelBooking;
using IRL.Bookings.Application.Commands.CreateBooking;
using IRL.Bookings.Application.Commands.UpdateBooking;
using IRL.Bookings.Application.Queries.GetBookings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            return BadRequest(new { errors = output.Errors });
        }

        /// <summary>
        /// Create booking.
        /// </summary>
        /// <response code="201">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>Booking confirmation.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateBookingResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateBookingCommand model, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(model, cancellationToken);

            if (output.IsValid)
            {
                return new ObjectResult(output.Payload) { StatusCode = StatusCodes.Status201Created };
            }

            return BadRequest(new { errors = output.Errors });
        }

        /// <summary>
        /// Update booking.
        /// </summary>
        /// <response code="204">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>No content.</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UpdateBookingResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateBookingCommand model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var output = await _mediator.Send(model, cancellationToken);

            if (output.IsValid)
            {
                return NoContent();
            }

            return BadRequest(new { errors = output.Errors });
        }

        /// <summary>
        /// Cancel booking.
        /// </summary>
        /// <response code="204">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>No content.</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CancelBookingResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cancel([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new CancelBookingCommand() { Id = id }, cancellationToken);

            if (output.IsValid)
            {
                return NoContent();
            }

            return BadRequest(new { errors = output.Errors });
        }
    }
}