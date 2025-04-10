using MediatR;

namespace CarrierAPI.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class RemoveCarrierCommandRequest: IRequest<RemoveCarrierCommandResponse>
    {
        public int Id { get; set; }
    }
}