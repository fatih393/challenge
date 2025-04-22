using MediatR;

namespace CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandRequest: IRequest<DataResult<RemoveCarrierCommandResponse>>
    {
        public int Id { get; set; }
    }
}