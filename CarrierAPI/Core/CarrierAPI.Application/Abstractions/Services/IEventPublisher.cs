using CarrierAPI.Domain.Entities.Common;


namespace CarrierAPI.Application.Abstractions.Services
{
       public interface IEventPublisher
    {
        Task PublishAsync<T>(T message);
    }
}
