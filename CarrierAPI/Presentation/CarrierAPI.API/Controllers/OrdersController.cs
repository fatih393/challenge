using CarrierAPI.Application.Features.Commands.Order.CreateOrder;
using CarrierAPI.Application.Features.Commands.Order.RemoveOrder;
using CarrierAPI.Application.Features.Commands.Order.SoftRemoveOrder;
using CarrierAPI.Application.Features.Queries.Order.GetOrder;
using CarrierAPI.Persistence.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarrierAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
           
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            var response = await _mediator.Send(createOrderCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> ListOrder([FromQuery] GetOrderQueryRequest getOrderQueryRequest)
        {
            var response = await _mediator.Send(getOrderQueryRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpDelete("hard/{Id}")]
        public async Task<IActionResult> RemoveOrder([FromRoute]RemoveOrderCommandRequest removeOrderCommandRequest)
        {
            var response = await _mediator.Send(removeOrderCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete("soft/{Id}")]
        public async Task<IActionResult> SoftRemoveOrder([FromRoute] SoftRemoveOrderCommandRequest softremoveOrderCommandRequest)
        {
            var response = await _mediator.Send(softremoveOrderCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

      
    }
}
