using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQueryRequest, GetCarrierQueryResponse>
    {
        readonly ICarrierService _carrierService;

        public GetCarrierQueryHandler(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        public async Task<GetCarrierQueryResponse> Handle(GetCarrierQueryRequest request, CancellationToken cancellationToken)
        {
           List< Domain.Entities.Carrier > carriers = await _carrierService.GetCarrierAsync();
            return new()
            {
                carriers = carriers,
            };
        }
    }
}
