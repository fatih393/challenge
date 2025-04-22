using MediatR;

namespace CarrierAPI.Application.Features.Queries.Carrier.GetCarrier
{
    public class GetCarrierQueryRequest: IRequest<DataResult<GetCarrierQueryResponse>>
    {
    }
}