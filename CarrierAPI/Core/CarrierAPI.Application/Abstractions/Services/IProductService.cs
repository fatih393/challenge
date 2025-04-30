using CarrierAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(string ProductName);
        Task<List<Product>> GetProductAsync();
        Task<bool> RemoveProductAsync(int id);
        Task<bool> UpdateProductAsync(int id, string name, bool active, int plusDesiCost);
    }
}
