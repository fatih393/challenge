using CarrierAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface ICarrierConfigurationService
    {
        Task<bool> AddCarrierConfiguration(int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost);
        Task<List<CarrierConfiguration>> GetCarrierConfigurationsAsync();
        Task<bool> RemoveCarrierConfigurationAsync(int id);
        Task<bool> UpdateCarrierConfigurationAsync(int id, int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost);
    }
}


