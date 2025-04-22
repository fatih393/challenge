using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Domain.Entities.Events.Carrier;
using CarrierAPI.Domain.Entities.Events.Order;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class CarrierService : ICarrierService
    {
        readonly ICarrierWriteRepository _carrierWriteRepository;
        readonly ICarrierReadRepository _carrierReadRepository;
        readonly IEventPublisher _eventPublisher;
        private readonly IBus _bus;
        private readonly IRedisCacheServices _redisCacheService;
        public CarrierService(ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository, IEventPublisher eventPublisher, IBus bus, IRedisCacheServices redisCacheService)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _carrierReadRepository = carrierReadRepository;
            _eventPublisher = eventPublisher;
            _bus = bus;
            _redisCacheService = redisCacheService;
        }

        public async Task<bool> AddCarrierAsync(string CarrierName, bool CarrierIsActive, int CarrierPlusDesiCost)
        {
            try
            {
                CarrierName=CarrierName.ToLower();
              var carriername = await _carrierReadRepository.GetWhere(c => c.CarrierName==CarrierName).FirstOrDefaultAsync();
                string carrierName = carriername?.CarrierName?.ToLower();
                if (carrierName != null)
                    return false;
                var newCarrier = new Carrier
                {
                    CarrierName = CarrierName.ToLower(),
                    CarriersActive = CarrierIsActive,
                    CarrierPlusDesiCost = CarrierPlusDesiCost
                };

                await _carrierWriteRepository.AddAsync(newCarrier);
                await _carrierWriteRepository.Saveasync();
                await _eventPublisher.PublishAsync(new PostCarrierEvent(newCarrier.Id, newCarrier.CarrierName));
               
                return true;
            }
            catch
            {
                return false;
            }
           
          
        }

        public  async Task<List<Carrier>> GetCarrierAsync()
        {
            string cacheKey = "CarrierList";

           // cache de var mı yok mu varsa döndür
            var cachedData = await _redisCacheService.GetCacheAsync<List<Carrier>>(cacheKey);
            if (cachedData != null)
            {
                Console.WriteLine(cacheKey + " Cache'ten geldi.");
                return cachedData;
            }

            // yoksa getir 
            List<Carrier> carriers = await _carrierReadRepository.GetAll(false).ToListAsync();

            // cache yaz
            await _redisCacheService.SetCacheAsync(cacheKey, carriers, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5));

            Console.WriteLine(cacheKey + " Cache'e eklendi.");

            await _eventPublisher.PublishAsync(new GetCarrierEvent());

            return carriers;
        }

        public async Task<bool> RemoveCarrierAsync(int id)
        {
            try
            {
                bool control = await _carrierWriteRepository.RemoveAsync(id);
                await _carrierWriteRepository.Saveasync();
                await _eventPublisher.PublishAsync(new RemoveCarrierEvent(id));
                return control;
            }
            catch
            {
                return true;
            }
          
        }

        public async Task<bool> UpdateCarrierAsync(int id, string name, bool active, int plusDesiCost )
        {
            try
            {
            Carrier carrier = await _carrierReadRepository.GetByIdAsync(id);
            carrier.CarrierName = name;
            carrier.CarriersActive = active;    
            carrier.CarrierPlusDesiCost= plusDesiCost;
            await _carrierWriteRepository.Saveasync();
            await _eventPublisher.PublishAsync(new PutCarrierEvent(id, carrier.CarrierName));
            return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
