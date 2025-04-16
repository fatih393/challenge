using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Hangfire
{
    public static class HangfireExtensions
    {
        public static IServiceCollection AddHangfireWithPostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
            {
                config.UsePostgreSqlStorage(configuration.GetConnectionString("PostgreSQL"));
            });

            services.AddHangfireServer();

            return services;
        }
    }
}
