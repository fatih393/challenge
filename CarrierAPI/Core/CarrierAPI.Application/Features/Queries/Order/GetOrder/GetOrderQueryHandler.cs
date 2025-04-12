using CarrierAPI.Application.Abstractions.Services;
using MediatR;
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

        public GetOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
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
