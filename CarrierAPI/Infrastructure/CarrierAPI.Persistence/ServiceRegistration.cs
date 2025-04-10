using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities.Identity;
using CarrierAPI.Persistence.Contexts;
using CarrierAPI.Persistence.Repostories;
using CarrierAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence
{
    public static  class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) { 
            services.AddDbContext<CarrierAPIContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<CarrierAPIContext>();

            services.AddScoped<ICarrierService, CarrierService>();
            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
        }
        
    }
}
