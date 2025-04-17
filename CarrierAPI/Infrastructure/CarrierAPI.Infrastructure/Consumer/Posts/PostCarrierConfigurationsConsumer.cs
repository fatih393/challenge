using CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Posts
{
    public class PostCarrierConfigurationsConsumer : IConsumer<PostCarrierConfigurationEvent>
    {
        public Task Consume(ConsumeContext<PostCarrierConfigurationEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier Configuration received: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
