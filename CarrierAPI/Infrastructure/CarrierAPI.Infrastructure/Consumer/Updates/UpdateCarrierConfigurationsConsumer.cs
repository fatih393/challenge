using CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Updates
{
    public class UpdateCarrierConfigurationsConsumer : IConsumer<PutCarrierConfigurationEvent>
    {
        public Task Consume(ConsumeContext<PutCarrierConfigurationEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier configurations is update: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
