using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Queries.WebScraping.GetWebScraping;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarrierAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebScrapingController : ControllerBase
    {
        readonly IMediator _mediator;

        public WebScrapingController(IMediator mediator)
        {

            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWebScrapingQueryRequest getWebScrapingQueryRequest)
        {
            GetWebScrapingQueryResponse response = await _mediator.Send(getWebScrapingQueryRequest);
         
            return Ok(response);
        }
    }
}
