using MediatR;

namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandRequest: IRequest<DataResult<UpdateCarrierConfigurationCommandResponse>>
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}