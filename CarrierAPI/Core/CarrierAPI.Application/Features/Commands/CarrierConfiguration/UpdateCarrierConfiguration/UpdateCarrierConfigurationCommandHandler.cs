using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;

        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            bool control = await _carrierConfigurationService.UpdateCarrierConfigurationAsync(
                request.Id, 
                request.CarrierId, 
                request.CarrierMaxDesi, 
                request.CarrierMinDesi,
                request.CarrierCost);
            if (control)
                return new()
                {
                    Message = "Güncelleme başarılı"
                };
            return new()
            {
                Message = "Güncelleme işleminde bir sorun oluştu"
            };
        }
    }
}
