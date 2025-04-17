using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Domain.Entities.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using MassTransit;

namespace CarrierAPI.Infrastructure
{
    public class RabbitMqPublisher : IEventPublisher
    {
        private readonly IBus _bus;

        public RabbitMqPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishAsync<T>(T message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Event message cannot be null");
            }

          //  var jsonMessage = JsonConvert.SerializeObject(message);
            Console.WriteLine("Publishing event: " + message);

            await _bus.Publish(message);
        }
    }
}
