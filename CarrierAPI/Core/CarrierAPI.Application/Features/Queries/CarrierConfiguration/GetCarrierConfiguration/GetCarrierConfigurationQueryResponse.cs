namespace CarrierAPI.Application.Features.Queries.CarrierConfiguration.GetCarrierConfiguration
{
    public class GetCarrierConfigurationQueryResponse
    {
        public List<Domain.Entities.CarrierConfiguration> carrierConfigurations  { get; set; }
        public string Message { get; set; }
    }
}