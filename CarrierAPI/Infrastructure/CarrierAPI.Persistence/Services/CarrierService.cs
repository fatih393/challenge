using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
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

        public CarrierService(ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<bool> AddCarrierAsync(string CarrierName, bool CarrierIsActive, int CarrierPlusDesiCost)
        {
            try
            {
            await _carrierWriteRepository.AddAsync(new()
            {
                CarrierName = CarrierName,
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
    }
}
