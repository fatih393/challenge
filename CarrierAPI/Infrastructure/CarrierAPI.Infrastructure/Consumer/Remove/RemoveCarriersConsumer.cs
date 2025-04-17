using CarrierAPI.Domain.Entities.Events.Carrier;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Remove
{
    public class RemoveCarriersConsumer : IConsumer<RemoveCarrierEvent>
    {
        public Task Consume(ConsumeContext<RemoveCarrierEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier remove: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
