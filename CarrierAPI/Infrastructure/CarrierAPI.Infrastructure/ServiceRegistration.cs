using CarrierAPI.Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static  void AddInfrastructureService(this IServiceCollection services)
        {

            services.AddScoped<IEventPublisher, RabbitMqPublisher>();
           

        }
    }
}
