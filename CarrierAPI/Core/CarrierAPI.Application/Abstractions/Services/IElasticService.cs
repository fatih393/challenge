using CarrierAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface IElasticService<T> where T : class
    {
        Task IndexAsync(T document, int id);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> SearchByNameAsync(string name);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, T document);
    }
}
