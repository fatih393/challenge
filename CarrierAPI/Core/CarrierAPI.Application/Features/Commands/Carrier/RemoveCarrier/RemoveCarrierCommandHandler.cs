using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandHandler : IRequestHandler<RemoveCarrierCommandRequest, DataResult<RemoveCarrierCommandResponse>>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<RemoveCarrierCommandHandler> _logger;
        public RemoveCarrierCommandHandler(ICarrierService carrierService, ILogger<RemoveCarrierCommandHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<DataResult<RemoveCarrierCommandResponse>> Handle(RemoveCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kargo şirketi silme");
            bool control = await _carrierService.RemoveCarrierAsync(request.Id);
            if (!control)
                return new SuccessDataResult<RemoveCarrierCommandResponse>(null, "Kayıt başarıyla silindi");
            return new ErrorDataResult<RemoveCarrierCommandResponse>();
        }
    }
}
