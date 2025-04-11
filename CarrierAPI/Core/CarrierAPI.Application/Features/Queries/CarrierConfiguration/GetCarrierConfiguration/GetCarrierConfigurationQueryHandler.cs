using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Queries.CarrierConfiguration.GetCarrierConfiguration
{
    public class GetCarrierConfigurationQueryHandler : IRequestHandler<GetCarrierConfigurationQueryRequest, GetCarrierConfigurationQueryResponse>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;

        public GetCarrierConfigurationQueryHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<GetCarrierConfigurationQueryResponse> Handle(GetCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.CarrierConfiguration> carrierConfigurations = await _carrierConfigurationService.GetCarrierConfigurationsAsync();
            if (carrierConfigurations == null)
                return new()
                {
                    Message = "Bir hata oluştu"
                };
            return new()
            {
                carrierConfigurations = carrierConfigurations
            };
        }
    }
}
