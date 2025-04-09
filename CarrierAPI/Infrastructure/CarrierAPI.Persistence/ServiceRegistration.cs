using CarrierAPI.Domain.Entities.Identity;
using CarrierAPI.Persistence.Contexts;
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
        }
    }
}
