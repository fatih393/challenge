using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Infrastructure.Consumer.Gets;
using CarrierAPI.Infrastructure.Consumer.Posts;
using CarrierAPI.Infrastructure.Consumer.Remove;
using CarrierAPI.Infrastructure.Consumer.Updates;
using CarrierAPI.Infrastructure.Service;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CarrierAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static  void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                
                x.AddConsumer<PostOrdersConsumer>();
                x.AddConsumer<GetOrdersConsumer>();
                x.AddConsumer<GetCarriersConsumer>();
                x.AddConsumer<GetCarrierConfigurationsConsumer>();
                x.AddConsumer<PostCarrierConfigurationsConsumer>();
                x.AddConsumer<PostCarriersConsumer>();
                x.AddConsumer<RemoveOrdersConsumer>();
                x.AddConsumer<RemoveCarriersConsumer>();
                x.AddConsumer<RemoveCarrierConfigurationsConsumer>();
                x.AddConsumer<UpdateCarriersConsumer>();
                x.AddConsumer<UpdateCarrierConfigurationsConsumer>();
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], "/", h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"]);
                        h.Password(configuration["RabbitMQ:Password"]);
                    });

                   
                   // cfg.ConfigureEndpoints(ctx); // Bunu queue oluştutrken 1 kez çalıştır oluştursun. Aaçık kalırsa bu kod sürekli üzerine oluşturacağından messagelar gelmez

                });
            });
         
            services.AddScoped<IEventPublisher, RabbitMqPublisher>();
            services.AddScoped<IExampleJobService, ExampleJobService>();
            services.AddScoped<IMailService, MailService>();

        }
    }
}
