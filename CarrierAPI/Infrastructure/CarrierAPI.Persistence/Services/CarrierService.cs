using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Domain.Entities.Events.Carrier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public CarrierService(ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository, IEventPublisher eventPublisher)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _carrierReadRepository = carrierReadRepository;
            _eventPublisher = eventPublisher;
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
            await _carrierWriteRepository.AddAsync(new()
            {
                CarrierName = CarrierName.ToLower(),
                CarriersActive = CarrierIsActive,
                CarrierPlusDesiCost = CarrierPlusDesiCost
            });
            await _carrierWriteRepository.Saveasync();
                return true;
            }
            catch
            {
                return false;
            }
           
          
        }

        public  async Task<List<Carrier>> GetCarrierAsync()
        {
            List<Carrier> carriers = await _carrierReadRepository.GetAll(false).ToListAsync();
            await _eventPublisher.PublishAsync(new GetCarrierEvent());
            return carriers;
        }

        public async Task<bool> RemoveCarrierAsync(int id)
        {
            try
            {
                bool control = await _carrierWriteRepository.RemoveAsync(id);
                await _carrierWriteRepository.Saveasync();
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
            return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
