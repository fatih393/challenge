using CarrierAPI.Application.Features.Commands.Order.CreateOrder;
using CarrierAPI.Application.Features.Commands.Order.RemoveOrder;
using CarrierAPI.Application.Features.Queries.Order.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> ListOrder([FromQuery] GetOrderQueryRequest getOrderQueryRequest)
        {
            GetOrderQueryResponse response = await _mediator.Send(getOrderQueryRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveOrder([FromRoute]RemoveOrderCommandRequest removeOrderCommandRequest)
        {
            RemoveOrderCommandResponse response = await _mediator.Send(removeOrderCommandRequest);
            return Ok(response);
        }
    }
}
