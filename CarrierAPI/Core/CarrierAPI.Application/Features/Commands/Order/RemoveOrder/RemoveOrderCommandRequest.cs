using MediatR;

namespace CarrierAPI.Application.Features.Commands.Order.RemoveOrder
{
    public class RemoveOrderCommandRequest: IRequest<RemoveOrderCommandResponse>
    {
        public int Id { get; set; }
    }
}