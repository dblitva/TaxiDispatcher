using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Queries.Ride;

namespace TaxiDispatcher.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RideController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("GetRidesByDay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRidesByDay([FromQuery] GetRidesByDayQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("OrderRide")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> OrderRide([FromBody] OrderRideCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("AcceptRide")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AcceptRide([FromBody] AcceptRideCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
