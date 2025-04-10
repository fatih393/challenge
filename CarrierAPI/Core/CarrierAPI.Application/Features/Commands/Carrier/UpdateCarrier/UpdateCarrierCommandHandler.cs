using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, UpdateCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;

        public UpdateCarrierCommandHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<UpdateCarrierCommandResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            bool control = await _carrierService.UpdateCarrierAsync(
                request.Id,
                request.Name,
                request.Active,
                request.PlusDesiCost);
            if (control)
                return new()
                {
                    Message = "Güncelleme işlemi başarılı"
                };
            return new()
            {
                Message = "Güncelleme işlemi başarısız"
            };
        }
    }
}
