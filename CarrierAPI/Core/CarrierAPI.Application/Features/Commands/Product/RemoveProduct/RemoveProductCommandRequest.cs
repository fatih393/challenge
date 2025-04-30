using MediatR;

namespace CarrierAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandRequest: IRequest<DataResult<RemoveProductCommandResponse>>
    {
        public int Id { get; set; }
    }
}