using CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier;
using CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using CarrierAPI.Application.Features.Commands.Carrier.UpdateCarrier;
using CarrierAPI.Application.Features.Queries.Carrier.GetCarrier;
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
        [HttpGet]
        public async Task<IActionResult> GetCarriers([FromQuery] GetCarrierQueryRequest getCarrierQueryRequest)
        {
            GetCarrierQueryResponse response = await _mediator.Send(getCarrierQueryRequest);
            return Ok(response);
        }
        [HttpDelete ("{Id}")]
        public async Task<IActionResult> RemoveCarriers([FromRoute] RemoveCarrierCommandRequest removeCarrierCommandRequest)
        {
            RemoveCarrierCommandResponse response = await _mediator.Send(removeCarrierCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarriers(UpdateCarrierCommandRequest updateCarrierCommandRequest)
        {
            UpdateCarrierCommandResponse response = await _mediator.Send(updateCarrierCommandRequest);
            return Ok(response);
        }
    
    }
}
