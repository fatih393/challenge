using CarrierAPI.Domain.Entities.Events.Order;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Posts
{
    public class PostOrdersConsumer : IConsumer<PostOrdersEvent>
    {
        public Task Consume(ConsumeContext<PostOrdersEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Order received: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
