using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier;
using CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using CarrierAPI.Application.Features.Commands.Carrier.UpdateCarrier;
using CarrierAPI.Application.Features.Queries.Carrier.GetCarrier;
using CarrierAPI.Infrastructure.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MassTransit.ValidationResultExtensions;

namespace CarrierAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IExampleJobService _exampleJobService;
        readonly IMailService _mailService;
       

        public CarriersController(IMediator mediator, IExampleJobService exampleJobService, IMailService mailService)
        {
            _mediator = mediator;
            _exampleJobService = exampleJobService;
            _mailService = mailService;
           
        }

        [HttpPost]
        public async Task<IActionResult> AddCarrier(CreateCarrierCommandRequest createCarrierCommandRequest)
        {
            var response = await _mediator.Send(createCarrierCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCarriers([FromQuery] GetCarrierQueryRequest getCarrierQueryRequest)
        {
            //await _mailService.SendMailAsync("yunusyildirim2002@gmail.com", "Bu bir deneme mailidir", "<strong>Test maili</strong>");
            /*  await _mailService.SendMailAsync(new[]
              {
                  "fatihhizli393@gmail.com",
                  "furkan_524@hotmail.com",
                  "yunusyildirim2002@gmail.com",
                  "174furkan@gmail.com"
              }, "Bu bir deneme mailidir", "<strong>Toplu Test maili</strong>");*/
            
            var response = await _mediator.Send(getCarrierQueryRequest);
            // BackgroundJob.Enqueue(() => _exampleJobService.RunExampleJob());
            if (response.Success)
                return Ok(response); 
            else
                return BadRequest(response);
        }
        [HttpDelete ("{Id}")]
        public async Task<IActionResult> RemoveCarriers([FromRoute] RemoveCarrierCommandRequest removeCarrierCommandRequest)
        {
            var response = await _mediator.Send(removeCarrierCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarriers(UpdateCarrierCommandRequest updateCarrierCommandRequest)
        {
            var response = await _mediator.Send(updateCarrierCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
    
    }
}
