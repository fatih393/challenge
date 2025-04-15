using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Domain.Entities.Events.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly IEventPublisher _eventPublisher;
        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, IEventPublisher eventPublisher)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<bool> AddOrder(int orderDesi)
        {
         var carrier =  await _carrierConfigurationReadRepository.Table
    .Include(x => x.Carrier)
    .Where(x => orderDesi >= x.CarrierMinDesi && orderDesi <= x.CarrierMaxDesi)
    .OrderBy(x => x.CarrierCost)
    .FirstOrDefaultAsync();
            if (carrier == null)
            {
                var secondCarrier = await _carrierConfigurationReadRepository.Table
                    .Include(x => x.Carrier)
                    .OrderBy(x => Math.Abs(orderDesi - x.CarrierMaxDesi))
                    .FirstOrDefaultAsync();
                if(secondCarrier == null) 
                    return false;
                var space = orderDesi - secondCarrier.CarrierMaxDesi;
                var plusPrice = space * secondCarrier.Carrier.CarrierPlusDesiCost;
                carrier = secondCarrier;
                carrier.CarrierCost = secondCarrier.CarrierCost + plusPrice;
                
            }
            Order order = new()
            {
                OrderDesi = orderDesi,
                CarrierId = carrier.Carrier.Id,
                OrderDate = DateTime.UtcNow,
                OrderCarrierCost = carrier.CarrierCost,
            };
            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.Saveasync();
            return true;
        }

        public async Task<List<Order>> GetOrders()
        {
            await _eventPublisher.PublishAsync(new GetOrdersEvent());
            try
            {
               
                return await _orderReadRepository.GetAll(false).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveOrder(int id)
        {
            try
            {
                await _orderWriteRepository.RemoveAsync(id);
                await _orderWriteRepository.Saveasync();
                return true;    
            }
            catch
            {
                return false;
            }
        }
    }
}
