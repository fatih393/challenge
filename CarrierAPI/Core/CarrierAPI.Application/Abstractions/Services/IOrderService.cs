using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<bool> AddOrder(int orderDesi);
        Task<List<Domain.Entities.Order>> GetOrders();
        Task<bool> RemoveOrder(int id);
    }
}
