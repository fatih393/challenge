using CarrierAPI.Domain.Entities.Events.Carrier;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Posts
{
    public class PostCarriersConsumer : IConsumer<PostCarrierEvent>
    {
        public Task Consume(ConsumeContext<PostCarrierEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier received: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
