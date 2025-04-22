using MediatR;

namespace CarrierAPI.Application.Features.Commands.Order.RemoveOrder
{
    public class RemoveOrderCommandRequest: IRequest<DataResult<RemoveOrderCommandResponse>>
    {
        public int Id { get; set; }
    }
}