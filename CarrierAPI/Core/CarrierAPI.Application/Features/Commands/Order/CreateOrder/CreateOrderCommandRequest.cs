using MediatR;

namespace CarrierAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest: IRequest<CreateOrderCommandResponse>
    {
        public int OrderDesi { get; set; }
    }
}