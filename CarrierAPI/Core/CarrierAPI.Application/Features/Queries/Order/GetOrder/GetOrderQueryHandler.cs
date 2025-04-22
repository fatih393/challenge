using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Queries.CarrierConfiguration.GetCarrierConfiguration;
using CarrierAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, DataResult<GetOrderQueryResponse>>
    {
        readonly IOrderService _orderService;
        readonly ILogger<GetOrderQueryHandler> _logger;
        public GetOrderQueryHandler(IOrderService orderService, ILogger<GetOrderQueryHandler> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<DataResult<GetOrderQueryResponse>> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Siparişleri listeleme");
            List<Domain.Entities.Order> order = await _orderService.GetOrders();
            if (order == null)
                return new ErrorDataResult<GetOrderQueryResponse>();
            var response = new GetOrderQueryResponse
            {
                orders = order
            };
            return new SuccessDataResult<GetOrderQueryResponse>(response, "Siparişler başarıyla listelendi.");
        }
    }
}
