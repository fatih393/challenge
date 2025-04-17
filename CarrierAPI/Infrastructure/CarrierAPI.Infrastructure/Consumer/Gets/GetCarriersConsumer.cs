using CarrierAPI.Domain.Entities.Events.Carrier;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Consumer.Gets
{
    public class GetCarriersConsumer : IConsumer<GetCarrierEvent>
    {
        public Task Consume(ConsumeContext<GetCarrierEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Carrier received: {message}");
            return Task.CompletedTask;
        }
    }
}
