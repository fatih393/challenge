using MediatR;

namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandRequest: IRequest<DataResult<RemoveCarrierConfigurationCommandResponse>>  
    {
        public int Id { get; set; }
    }
}