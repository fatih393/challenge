using CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Gets
{
    public class GetCarrierConfigurationsConsumer : IConsumer<GetCarrierConfigurationsEvent>
    {
        public Task Consume(ConsumeContext<GetCarrierConfigurationsEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"CarrierConfigurations received: {message}");
            return Task.CompletedTask;
        }
    }
}
