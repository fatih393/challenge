using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<bool> AddOrder(int orderDesi, int productId);
        Task<List<Domain.Entities.Order>> GetOrders();
        Task<bool> RemoveOrder(int id);
        Task<bool> SoftRemoveOrder(int id);
    }
}
