using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.DTOs;
using CarrierAPI.Application.Features.Commands.Order.CreateOrder;
using CarrierAPI.Application.Features.Commands.Product.CreateProduct;
using CarrierAPI.Application.Features.Commands.Product.RemoveProduct;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Persistence.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarrierAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IElasticService<ProductDto> _elasticService;

        public ProductsController(IMediator mediator, IElasticService<ProductDto> elasticService)
        {
            _mediator = mediator;
            _elasticService = elasticService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            var response = await _mediator.Send(createProductCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(RemoveProductCommandRequest removeProductCommandRequest)
        {
            var response = await _mediator.Send(removeProductCommandRequest);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpPost("elastic")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _elasticService.IndexAsync(productDto, productDto.Id);
            return Ok(productDto);
        }

        [HttpGet("elastic")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var products = await _elasticService.SearchByNameAsync(name);
            return Ok(products);
        }


        [HttpGet("elastic/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _elasticService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Ürün id: {id} bulunamadı.");
            }

            return Ok(product);
        }

       
        [HttpPut("elastic/{id}")]
        public async Task<IActionResult> Update(int id, ProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest("Ürün id'si uyumsuz.");
            }

            var existingProduct = await _elasticService.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound($"Ürün id: {id} bulunamadı.");
            }

           
            bool updated = await _elasticService.UpdateAsync(id, product);
            if (updated)
            {
                return Ok(product);
            }

            return BadRequest("Ürün güncellenemedi.");
        }

        
        [HttpDelete("elastic/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _elasticService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Ürün id: {id} bulunamadı.");
            }

           
            bool deleted = await _elasticService.DeleteAsync(id);
            if (deleted)
            {
                return Ok($"Ürün id: {id} başarıyla silindi.");
            }

            return BadRequest("Ürün silinemedi.");
        }
    }
}
