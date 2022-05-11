using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiDispatcher.Application.Commands.Taxi;
using TaxiDispatcher.Application.Queries.Taxi;

namespace TaxiDispatcher.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTaxisQuery());
            return Ok(result);
        }

        [HttpGet("getById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromQuery] GetTaxiByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromBody] TaxiInsertCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
