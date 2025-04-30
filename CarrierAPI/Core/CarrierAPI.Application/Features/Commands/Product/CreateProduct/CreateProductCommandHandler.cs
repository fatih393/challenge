using CarrierAPI.Application.Abstractions;
using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Order.CreateOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, DataResult<CreateProductCommandResponse>>
    {
        readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<DataResult<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            bool control =await _productService.AddProductAsync(request.Name);
            if (control)
                return new SuccessDataResult<CreateProductCommandResponse>(null, "Ürün başarıyla oluşturuldu");
            return new ErrorDataResult<CreateProductCommandResponse>();
        }
    }
}
