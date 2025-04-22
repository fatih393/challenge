using MediatR;

namespace CarrierAPI.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CreateCarrierCommandRequest : IRequest<DataResult<CreateCarrierCommandResponse>>
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; } = true;
        public int CarrierPlusDesiCost { get; set; }

    }
}