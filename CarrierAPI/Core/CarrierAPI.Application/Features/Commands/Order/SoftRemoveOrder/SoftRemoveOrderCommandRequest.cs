using MediatR;

namespace CarrierAPI.Application.Features.Commands.Order.SoftRemoveOrder
{
    public class SoftRemoveOrderCommandRequest: IRequest<DataResult<SoftRemoveOrderCommandResponse>>
    {
        public int Id { get; set; }
    }
}