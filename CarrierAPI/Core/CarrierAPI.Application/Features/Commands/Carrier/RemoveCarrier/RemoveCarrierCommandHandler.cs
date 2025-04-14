using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandHandler : IRequestHandler<RemoveCarrierCommandRequest, RemoveCarrierCommandResponse>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<RemoveCarrierCommandHandler> _logger;
        public RemoveCarrierCommandHandler(ICarrierService carrierService, ILogger<RemoveCarrierCommandHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<RemoveCarrierCommandResponse> Handle(RemoveCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kargo şirketi silme");
            bool control = await _carrierService.RemoveCarrierAsync(request.Id);
            if (!control)
                return new()
                {
                    Message = "Silme işlemi başarılı"
                };
            return new()
            {
                Message = "Silme işlemi başarısız"
            };
        }
    }
}
