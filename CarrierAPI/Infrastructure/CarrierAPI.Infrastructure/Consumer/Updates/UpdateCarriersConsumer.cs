using CarrierAPI.Domain.Entities.Events.Carrier;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Updates
{
    public class UpdateCarriersConsumer : IConsumer<PutCarrierEvent>
    {
        public Task Consume(ConsumeContext<PutCarrierEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier update: {message.Id}");
            return Task.CompletedTask;
        }
    }
}
