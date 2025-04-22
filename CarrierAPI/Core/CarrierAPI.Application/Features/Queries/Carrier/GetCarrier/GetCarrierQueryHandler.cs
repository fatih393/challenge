using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CarrierAPI.Application.Features.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQueryRequest, DataResult<GetCarrierQueryResponse>>
    {
        readonly ICarrierService _carrierService;
        readonly ILogger<GetCarrierQueryHandler> _logger;
        public GetCarrierQueryHandler(ICarrierService carrierService, ILogger<GetCarrierQueryHandler> logger)
        {
            _carrierService = carrierService;
            _logger = logger;
        }

        public async Task<DataResult<GetCarrierQueryResponse>> Handle(GetCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            try
{
           List< Domain.Entities.Carrier > carriers = await _carrierService.GetCarrierAsync();
            _logger.LogInformation("Kargo şirketleri listelendi");
                return new SuccessDataResult<GetCarrierQueryResponse>(
                     new GetCarrierQueryResponse { carriers = carriers },
                    "Kargo şirketleri başarıyla listelendi."
                    ); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kargo şirketleri listelenirken bir hata oluştu.");
                return new ErrorDataResult<GetCarrierQueryResponse>();
            }

        }
    }
}
