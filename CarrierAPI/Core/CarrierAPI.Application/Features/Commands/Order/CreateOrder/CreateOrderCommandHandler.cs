using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly ILogger<CreateOrderCommandHandler> _logger;
        public CreateOrderCommandHandler(IOrderService orderService, ILogger<CreateOrderCommandHandler> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sipariş ekleme");
            bool control = await _orderService.AddOrder(request.OrderDesi);
            if (control)
                return new()
                {
                    Message = "Sipariş başarıyla alındı"
                };
            return new()
            {
                Message = "Sipariş alınırken bir hata oluştu"
            };
        }
    }
}
