using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQueryRequest, GetCarrierQueryResponse>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<GetCarrierQueryHandler> _logger;
        public GetCarrierQueryHandler(ICarrierService carrierService, ILogger<GetCarrierQueryHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<GetCarrierQueryResponse> Handle(GetCarrierQueryRequest request, CancellationToken cancellationToken)
        {

           List< Domain.Entities.Carrier > carriers = await _carrierService.GetCarrierAsync();
            _logger.LogInformation("Kargo şirketleri listelendi");
            return new()
            {
                carriers = carriers,
            };
        }
    }
}
