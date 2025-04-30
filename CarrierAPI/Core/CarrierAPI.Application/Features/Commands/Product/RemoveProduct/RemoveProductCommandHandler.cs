using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.Product.CreateProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, DataResult<RemoveProductCommandResponse>>
    {
        readonly IProductService _productService;
        public async Task<DataResult<RemoveProductCommandResponse>> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool control = await _productService.RemoveProductAsync(request.Id);
            if (control)
                return new SuccessDataResult<RemoveProductCommandResponse>(null, "Ürün başarıyla oluşturuldu");
            return new ErrorDataResult<RemoveProductCommandResponse>();
        }
    }
}
