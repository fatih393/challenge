using CarrierAPI.Domain.Entities.Events.Carrier;
using CarrierAPI.Domain.Entities.Events.Order;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Gets
{
    public class GetOrdersConsumer : IConsumer<GetOrdersEvent>
    {
        public Task Consume(ConsumeContext<GetOrdersEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Order received: {message}");
            return Task.CompletedTask;
        }
    }
}
