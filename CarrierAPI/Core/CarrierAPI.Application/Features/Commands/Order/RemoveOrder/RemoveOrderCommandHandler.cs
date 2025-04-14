using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Order.RemoveOrder
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommandRequest, RemoveOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly ILogger<RemoveOrderCommandHandler> _logger;
        public RemoveOrderCommandHandler(IOrderService orderService, ILogger<RemoveOrderCommandHandler> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<RemoveOrderCommandResponse> Handle(RemoveOrderCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sipariş silme");
            if (await _orderService.RemoveOrder(request.Id))
                return new()
                {
                    Message = "Silme işlemi başarılı"
                };
            return new()
            {
                Message = "Silme işlemi başarısız"
            };
        }
    }
}
