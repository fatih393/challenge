using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationCommandResponse>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;

        public CreateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<CreateCarrierConfigurationCommandResponse> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _carrierConfigurationService.AddCarrierConfiguration(request.CarrierId, request.CarrierMaxDesi, request.CarrierMinDesi, request.CarrierCost))
                return new()
                {
                    Message = "Ekleme işlemi başarılı"
                };
            return new()
            {
                Message = "Ekleme işleminde bir sorun oluştu"
            };
        }
    }
}
