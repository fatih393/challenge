using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities.Identity;
using CarrierAPI.Persistence.Contexts;
using CarrierAPI.Persistence.Repostories;
using CarrierAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Elastic.Clients.Elasticsearch;
using CarrierAPI.Domain.Entities;

namespace CarrierAPI.Persistence
{
    public static  class ServiceRegistration
    {
       
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) { 
            services.AddDbContext<CarrierAPIContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<CarrierAPIContext>();

            services.AddScoped<ICarrierService, CarrierService>();
            services.AddScoped<ICarrierConfigurationService, CarrierConfigurationService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
            services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();
            services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductService, ProductService>();
           /* services.AddScoped<IElasticService<Product>, ElasticService<Product>>();
            ElasticsearchClientSettings settings = new(new Uri("http://localhost:9200"));
            settings.DefaultIndex("products");
            ElasticsearchClient client = new ElasticsearchClient(settings);
            client.IndexAsync("products").GetAwaiter().GetResult();*/
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "CarrierAPI_"; 
            });

        }
        
    }
}
