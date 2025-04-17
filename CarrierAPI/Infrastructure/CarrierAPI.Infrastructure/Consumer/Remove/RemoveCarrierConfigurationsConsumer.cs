using CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Remove
{
    public class RemoveCarrierConfigurationsConsumer : IConsumer<RemoveCarrierConfigurationEvent>
    {
        public Task Consume(ConsumeContext<RemoveCarrierConfigurationEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier configuration is remove: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
