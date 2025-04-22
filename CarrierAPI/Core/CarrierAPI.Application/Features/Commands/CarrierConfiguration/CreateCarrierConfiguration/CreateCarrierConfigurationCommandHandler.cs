using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, DataResult<CreateCarrierConfigurationCommandResponse>>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;
        readonly ILogger<CreateCarrierConfigurationCommandHandler> _logger;
        public CreateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService, ILogger<CreateCarrierConfigurationCommandHandler> logger)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _logger = logger;
        }

        public async Task<DataResult<CreateCarrierConfigurationCommandResponse>> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Konfigürasyon ekleme");
            if (await _carrierConfigurationService.AddCarrierConfiguration(request.CarrierId, request.CarrierMaxDesi, request.CarrierMinDesi, request.CarrierCost))
                return new SuccessDataResult<CreateCarrierConfigurationCommandResponse>(null, "Kayıt başarıyla oluşturuldu");
            return new ErrorDataResult<CreateCarrierConfigurationCommandResponse>();
        }
    }
}
