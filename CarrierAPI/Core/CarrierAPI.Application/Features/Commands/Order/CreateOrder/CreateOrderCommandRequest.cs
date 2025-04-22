using MediatR;

namespace CarrierAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest: IRequest<DataResult<CreateOrderCommandResponse>>
    {
        public int OrderDesi { get; set; }
    }
}