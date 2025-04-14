using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, UpdateCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<UpdateCarrierCommandHandler> _logger;
        public UpdateCarrierCommandHandler(ICarrierService carrierService, ILogger<UpdateCarrierCommandHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<UpdateCarrierCommandResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kargo şirketi güncelleme");
            bool control = await _carrierService.UpdateCarrierAsync(
                request.Id,
                request.Name,
                request.Active,
                request.PlusDesiCost);
            if (control)
                return new()
                {
                    Message = "Güncelleme işlemi başarılı"
                };
            return new()
            {
                Message = "Güncelleme işlemi başarısız"
            };
        }
    }
}
