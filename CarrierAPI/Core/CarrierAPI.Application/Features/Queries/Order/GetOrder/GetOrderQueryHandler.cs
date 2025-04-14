using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GetOrderQueryResponse>
    {
        readonly IOrderService _orderService;
        readonly ILogger<GetOrderQueryHandler> _logger;
        public GetOrderQueryHandler(IOrderService orderService, ILogger<GetOrderQueryHandler> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Siparişleri listeleme");
            List<Domain.Entities.Order> order = await _orderService.GetOrders();
            if (order == null)
                return new()
                {
                    Message = "Listeleme başarısız"
                };
            return new()
            {
                orders = order,
                Message = "Listeleme başarılı"
            };
        }
    }
}
