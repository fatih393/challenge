using CarrierAPI.Domain.Entities;

namespace CarrierAPI.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryResponse
    {
        public List<Domain.Entities.Order> orders { get; set; }
        public string Message { get; set; }
    }
}