using CarrierAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class RemoveCarrierConfigurationCommandHandler : IRequestHandler<RemoveCarrierConfigurationCommandRequest, RemoveCarrierConfigurationCommandResponse>
    {
        readonly ICarrierConfigurationService _carrierConfigurationService;

        public RemoveCarrierConfigurationCommandHandler(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        public async Task<RemoveCarrierConfigurationCommandResponse> Handle(RemoveCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _carrierConfigurationService.RemoveCarrierConfigurationAsync(request.Id))
                return new()
                {
                    Message= "Silme işlemi başarılı"
                };
            return new()
            {
                Message = "Silme işleminde bir hata oluştu"
            };
        }
    }
}
