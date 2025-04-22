using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, DataResult<UpdateCarrierCommandResponse>>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<UpdateCarrierCommandHandler> _logger;
        public UpdateCarrierCommandHandler(ICarrierService carrierService, ILogger<UpdateCarrierCommandHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<DataResult<UpdateCarrierCommandResponse>> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kargo şirketi güncelleme");
            bool control = await _carrierService.UpdateCarrierAsync(
                request.Id,
                request.Name,
                request.Active,
                request.PlusDesiCost);
            if (control)
                return new SuccessDataResult<UpdateCarrierCommandResponse>(null, "Kayıt başarıyla güncellendi");
            return new ErrorDataResult<UpdateCarrierCommandResponse>();
        }
    }
}
