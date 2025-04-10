using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;

        public CreateCarrierCommandHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
           bool control= await _carrierService.AddCarrierAsync(request.CarrierName, request.CarrierIsActive, request.CarrierPlusDesiCost);
           if (control) 
            return new()
            {
                    Message="Kayıt başarılı"
                    
            };
            return new()
            {
                Message = "Kayıt başarısız"
            };
        }
    }
}
