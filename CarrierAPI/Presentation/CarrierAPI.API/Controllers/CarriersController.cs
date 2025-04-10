using CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrierAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        readonly IMediator _mediator;

        public CarriersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCarrier(CreateCarrierCommandRequest createCarrierCommandRequest)
        {
            CreateCarrierCommandResponse response = await _mediator.Send(createCarrierCommandRequest);
            return Ok(response);
        }
    }
}
