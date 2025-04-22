using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, DataResult<UpdateCarrierConfigurationCommandResponse>>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;
        readonly ILogger<UpdateCarrierConfigurationCommandHandler> _logger;
        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService, ILogger<UpdateCarrierConfigurationCommandHandler> logger)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _logger = logger;
        }

        public async Task<DataResult<UpdateCarrierConfigurationCommandResponse>> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Konfigürasyon güncelleme");
            bool control = await _carrierConfigurationService.UpdateCarrierConfigurationAsync(
                request.Id, 
                request.CarrierId, 
                request.CarrierMaxDesi, 
                request.CarrierMinDesi,
                request.CarrierCost);
            if (control)
                return new SuccessDataResult<UpdateCarrierConfigurationCommandResponse>(null, "Kayıt başarıyla güncellendi");
            return new ErrorDataResult<UpdateCarrierConfigurationCommandResponse>();
        }
    }
}
