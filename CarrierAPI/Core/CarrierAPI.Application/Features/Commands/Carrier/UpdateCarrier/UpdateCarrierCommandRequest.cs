using MediatR;

namespace CarrierAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandRequest: IRequest<UpdateCarrierCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int PlusDesiCost { get; set; }

    }
}
// int id, string name, bool active, int plusDesiCost