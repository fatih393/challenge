using MediatR;

namespace CarrierAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest: IRequest<DataResult<CreateProductCommandResponse>>
    {
        public string Name { get; set; }
       
    }
}