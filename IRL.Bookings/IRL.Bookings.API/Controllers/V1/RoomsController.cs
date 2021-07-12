using AutoMapper;
using IRL.Bookings.Application.Queries.GetRooms;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.Bookings.API.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomsController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all rooms.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="cancellationToken"></param>
        /// <returns>All rooms.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRoomsResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetRoomsQuery model, CancellationToken cancellationToken)
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