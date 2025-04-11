using MediatR;

namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandRequest: IRequest<RemoveCarrierConfigurationCommandResponse>  
    {
        public int Id { get; set; }
    }
}