using CarrierAPI.Domain.Entities.Events.Order;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Remove
{
    public class RemoveOrdersConsumer : IConsumer<RemoveOrdersEvent>
    {
        public Task Consume(ConsumeContext<RemoveOrdersEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Order remove: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
