using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Order.CreateOrder;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Order.RemoveOrder
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommandRequest, DataResult<RemoveOrderCommandResponse>>
    {
        readonly IOrderService _orderService;
        readonly ILogger<RemoveOrderCommandHandler> _logger;
        public RemoveOrderCommandHandler(IOrderService orderService, ILogger<RemoveOrderCommandHandler> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<DataResult<RemoveOrderCommandResponse>> Handle(RemoveOrderCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sipariş silme");
            if (await _orderService.RemoveOrder(request.Id))
                return new SuccessDataResult<RemoveOrderCommandResponse>(null, "Sipariş başarıyla silindi");
            return new ErrorDataResult<RemoveOrderCommandResponse>();
        }
    }
}
