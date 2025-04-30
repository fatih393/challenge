using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _readrepository;
        readonly IProductWriteRepository _writerepository;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;

        public ProductService(IProductReadRepository readrepository, IProductWriteRepository writerepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _readrepository = readrepository;
            _writerepository = writerepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<bool> AddProductAsync(string ProductName)
        {
            Product product = new()
            {
                Name = ProductName,
               
            };
            await _writerepository.AddAsync(product);
            await _writerepository.Saveasync();
            return true;
        }

        public Task<List<Product>> GetProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
           {
             Product product = await _readrepository.GetByIdAsync(id);
            Order order = await _orderReadRepository.GetByIdAsync(product.Id);
            order.ProductId = null;
            await _orderWriteRepository.Saveasync();

            await _writerepository.RemoveAsync(id);
            await _writerepository.Saveasync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Task<bool> UpdateProductAsync(int id, string name, bool active, int plusDesiCost)
        {
            throw new NotImplementedException();
        }
    }
}
