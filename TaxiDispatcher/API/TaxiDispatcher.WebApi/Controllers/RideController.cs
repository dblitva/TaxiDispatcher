using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Commands.Taxi;
using TaxiDispatcher.Application.Queries.Taxi;

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

        [HttpPost("OrderRide")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> OrderRide([FromBody] OrderRideCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
