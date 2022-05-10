using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTaxiByIdQuery { Id = id });
            return Ok(result);
        }
    }
}
