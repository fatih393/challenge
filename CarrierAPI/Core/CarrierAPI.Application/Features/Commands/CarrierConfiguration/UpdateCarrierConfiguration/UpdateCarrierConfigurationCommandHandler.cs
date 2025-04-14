using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;
        readonly ILogger<UpdateCarrierConfigurationCommandHandler> _logger;
        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService, ILogger<UpdateCarrierConfigurationCommandHandler> logger)
        {
            _carrierConfigurationService = carrierConfigurationService;
            _logger = logger;
        }

        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Konfigürasyon güncelleme");
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
