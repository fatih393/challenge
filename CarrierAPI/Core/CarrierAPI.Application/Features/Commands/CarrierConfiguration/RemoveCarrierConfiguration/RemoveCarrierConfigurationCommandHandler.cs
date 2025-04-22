using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandHandler : IRequestHandler<RemoveCarrierConfigurationCommandRequest, DataResult<RemoveCarrierConfigurationCommandResponse>>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;
        readonly ILogger<RemoveCarrierConfigurationCommandHandler> _logger;
        public RemoveCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService, ILogger<RemoveCarrierConfigurationCommandHandler> logger)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _logger = logger;
        }

        public async Task<DataResult<RemoveCarrierConfigurationCommandResponse>> Handle(RemoveCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Konfigürasyon silme");
            if (await _carrierConfigurationService.RemoveCarrierConfigurationAsync(request.Id))
                return new SuccessDataResult<RemoveCarrierConfigurationCommandResponse>(null, "Kayıt başarıyla silindi");
            return new ErrorDataResult<RemoveCarrierConfigurationCommandResponse>();
        }
    }
}
