using CarrierAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface ICarrierService
    {
        Task<bool> AddCarrierAsync(string CarrierName, bool CarrierIsActive, int CarrierPlusDesiCost);
        Task<List<Carrier>> GetCarrierAsync();
        Task<bool> RemoveCarrierAsync(int id);
        Task<bool> UpdateCarrierAsync(int id, string name, bool active, int plusDesiCost);
    }
}
