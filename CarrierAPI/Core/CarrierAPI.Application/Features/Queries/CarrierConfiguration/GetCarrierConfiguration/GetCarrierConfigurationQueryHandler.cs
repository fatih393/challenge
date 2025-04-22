using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Queries.CarrierConfiguration.GetCarrierConfiguration
{
    public class GetCarrierConfigurationQueryHandler : IRequestHandler<GetCarrierConfigurationQueryRequest, DataResult<GetCarrierConfigurationQueryResponse>>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;
        readonly ILogger<GetCarrierConfigurationQueryHandler> _logger;
        public GetCarrierConfigurationQueryHandler(ICarrierConfigurationService carrierConfigurationService, ILogger<GetCarrierConfigurationQueryHandler> logger)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _logger = logger;
        }

        public async Task<DataResult<GetCarrierConfigurationQueryResponse>> Handle(GetCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Konfigürasyonları listeleme");
            List<Domain.Entities.CarrierConfiguration> carrierConfigurations = await _carrierConfigurationService.GetCarrierConfigurationsAsync();
            if (carrierConfigurations == null)
                return new ErrorDataResult<GetCarrierConfigurationQueryResponse>();
            var response = new GetCarrierConfigurationQueryResponse
            {
                carrierConfigurations = carrierConfigurations
            };
            return new SuccessDataResult<GetCarrierConfigurationQueryResponse>(response, "Konfigürasyonlar başarıyla listelendi.");
        }
    }
}
