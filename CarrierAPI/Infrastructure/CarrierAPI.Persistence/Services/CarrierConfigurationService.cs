using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace CarrierAPI.Persistence.Services
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
      readonly IEventPublisher _eventPublisher;
        private readonly IRedisCacheServices _redisCacheService;
        public CarrierConfigurationService(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, IEventPublisher eventPublisher, IRedisCacheServices redisCacheService)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _eventPublisher = eventPublisher;
            _redisCacheService = redisCacheService;
        }

        public async Task<bool> AddCarrierConfiguration(int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost)
        {
            try
            {
             CarrierConfiguration new_carrierConfiguration  = (new()
                {
                    CarrierId = CarrierId,
                    CarrierMaxDesi = CarrierMaxDesi,
                    CarrierMinDesi = CarrierMinDesi,
                    CarrierCost = CarrierCost

                });
                await _carrierConfigurationWriteRepository.AddAsync(new_carrierConfiguration);
                await _carrierConfigurationWriteRepository.Saveasync();
                await _eventPublisher.PublishAsync(new PostCarrierConfigurationEvent(new_carrierConfiguration.Id));
                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task<List<CarrierConfiguration>> GetCarrierConfigurationsAsync()
        {
            string cacheKey = "CarrierConfigurationList";
            try
            {
                var cachedData = await _redisCacheService.GetCacheAsync<List<CarrierConfiguration>>(cacheKey);
                if (cachedData != null)
                {
                    Console.WriteLine(cacheKey + " Cache'ten geldi.");
                    return cachedData;
                }
                List<CarrierConfiguration> carrierConfiguration = await _carrierConfigurationReadRepository.GetAll(false).ToListAsync();
                await _redisCacheService.SetCacheAsync(cacheKey, carrierConfiguration, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(5));
                Console.WriteLine(cacheKey + " Cache'e eklendi.");
                await _eventPublisher.PublishAsync(new GetCarrierConfigurationsEvent());
                return carrierConfiguration;
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> RemoveCarrierConfigurationAsync(int id)
        {
            try
            {
                await _carrierConfigurationWriteRepository.RemoveAsync(id);
                await _carrierConfigurationWriteRepository.Saveasync();
                await _eventPublisher.PublishAsync(new RemoveCarrierConfigurationEvent(id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCarrierConfigurationAsync(int id, int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost)
        {
            try
            {
            CarrierConfiguration carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(id);
            carrierConfiguration.CarrierId = CarrierId;
            carrierConfiguration.CarrierMaxDesi = CarrierMaxDesi;
            carrierConfiguration.CarrierMinDesi = CarrierMinDesi;
            carrierConfiguration.CarrierCost = CarrierCost;
            await _carrierConfigurationWriteRepository.Saveasync();
                await _eventPublisher.PublishAsync(new PutCarrierConfigurationEvent(id));
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
