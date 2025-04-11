using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Persistence.Repostories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CarrierConfigurationService(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<bool> AddCarrierConfiguration(int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost)
        {
            try
            {
                await _carrierConfigurationWriteRepository.AddAsync(new()
                {
                    CarrierId = CarrierId,
                    CarrierMaxDesi = CarrierMaxDesi,
                    CarrierMinDesi = CarrierMinDesi,
                    CarrierCost = CarrierCost

                });
                await _carrierConfigurationWriteRepository.Saveasync();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task<List<CarrierConfiguration>> GetCarrierConfigurationsAsync()
        {
            try
            {
                List<CarrierConfiguration> carrierConfiguration = await _carrierConfigurationReadRepository.GetAll(false).ToListAsync();
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
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
