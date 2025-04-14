using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<CreateCarrierCommandHandler> _logger;
        public CreateCarrierCommandHandler(ICarrierService carrierService, ILogger<CreateCarrierCommandHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kargo şirketi ekleme");
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
