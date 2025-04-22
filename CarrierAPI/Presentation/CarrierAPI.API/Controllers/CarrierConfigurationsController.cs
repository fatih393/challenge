using CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using CarrierAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using CarrierAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration;
using CarrierAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using CarrierAPI.Application.Features.Queries.CarrierConfiguration.GetCarrierConfiguration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrierAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        readonly IMediator _mediator;

        public CarrierConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCarrierConfiguration(CreateCarrierConfigurationCommandRequest createCarrierConfigurationCommandRequest)
        {
            var response = await _mediator.Send(createCarrierConfigurationCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCarrierConfiguration([FromQuery] GetCarrierConfigurationQueryRequest getCarrierConfigurationQueryRequest)
        {
            var response = await _mediator.Send(getCarrierConfigurationQueryRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveCarrierConfiguration([FromRoute] RemoveCarrierConfigurationCommandRequest removeCarrierConfigurationCommandRequest)
        {
            var response = await _mediator.Send(removeCarrierConfigurationCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarrierConfiguration( UpdateCarrierConfigurationCommandRequest updateCarrierConfigurationCommandRequest)
        {
            var response = await _mediator.Send(updateCarrierConfigurationCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }


    }
}
