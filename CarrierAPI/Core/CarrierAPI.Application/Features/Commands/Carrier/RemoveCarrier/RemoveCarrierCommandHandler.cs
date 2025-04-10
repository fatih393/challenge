using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandHandler : IRequestHandler<RemoveCarrierCommandRequest, RemoveCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;

        public RemoveCarrierCommandHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<RemoveCarrierCommandResponse> Handle(RemoveCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            bool control = await _carrierService.RemoveCarrierAsync(request.Id);
            if (!control)
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
