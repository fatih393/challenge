using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Order.RemoveOrder
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommandRequest, RemoveOrderCommandResponse>
    {
        readonly IOrderService _orderService;

        public RemoveOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<RemoveOrderCommandResponse> Handle(RemoveOrderCommandRequest request, CancellationToken cancellationToken)
        {
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
