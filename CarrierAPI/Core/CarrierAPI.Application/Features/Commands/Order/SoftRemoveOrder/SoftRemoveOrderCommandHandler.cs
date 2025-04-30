using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Order.RemoveOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Order.SoftRemoveOrder
{
    public class SoftRemoveOrderCommandHandler : IRequestHandler<SoftRemoveOrderCommandRequest, DataResult<SoftRemoveOrderCommandResponse>>
    {
        readonly IOrderService _orderService;

        public SoftRemoveOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<DataResult<SoftRemoveOrderCommandResponse>> Handle(SoftRemoveOrderCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _orderService.SoftRemoveOrder(request.Id))
                return new SuccessDataResult<SoftRemoveOrderCommandResponse>(null, "Sipariş başarıyla silindi");
            return new ErrorDataResult<SoftRemoveOrderCommandResponse>();
        }
    }
}
