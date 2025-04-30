using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Domain.Entities.Events.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly IEventPublisher _eventPublisher;
        private readonly IRedisCacheServices _redisCacheService;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, IEventPublisher eventPublisher, IRedisCacheServices redisCacheService, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _eventPublisher = eventPublisher;
            _redisCacheService = redisCacheService;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<bool> AddOrder(int orderDesi, int productId)
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
                ProductId = productId
            };
            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.Saveasync();
            var product = await _productReadRepository.GetByIdAsync(productId);
            product.OrderId = order.Id;
          
           
            await _productWriteRepository.Saveasync();
           // await _eventPublisher.PublishAsync(new PostOrdersEvent(order.Id, order.OrderDesi));
            return true;
        }

        public async Task<List<Order>> GetOrders()
        {
            string cacheKey = "OrderList";
           
            try
            {
                var cachedData = await _redisCacheService.GetCacheAsync<List<Order>>(cacheKey);
                if (cachedData != null)
                {
                    Console.WriteLine(cacheKey + "Cache'ten geldi.");
                    return cachedData;
                }
                List<Order> orders =  await _orderReadRepository.GetAll(false).Where(order => order.Visibility == true).ToListAsync();
                await _redisCacheService.SetCacheAsync(cacheKey, orders, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5));

                Console.WriteLine(cacheKey + " Cache'e eklendi.");
             //   await _eventPublisher.PublishAsync(new GetOrdersEvent());
                return orders;
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
                Order order = await _orderReadRepository.GetByIdAsync(id);
                Product product = await _productReadRepository.GetByIdAsync(order.ProductId.Value);
                product.OrderId = null;
                await _productWriteRepository.Saveasync();
                await _orderWriteRepository.RemoveAsync(id);
                await _orderWriteRepository.Saveasync();
           //     await _eventPublisher.PublishAsync(new RemoveOrdersEvent(id));
                return true;    
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SoftRemoveOrder(int id)
        {
            try
            {
                Order order = await _orderReadRepository.GetByIdAsync(id);
                order.Visibility = false;
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
