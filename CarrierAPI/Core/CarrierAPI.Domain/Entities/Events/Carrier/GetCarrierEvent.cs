using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Carrier
{
    public class GetCarrierEvent
    {
        public DateTime CarrierDate { get; set; }
        public GetCarrierEvent()
        {
            CarrierDate = DateTime.UtcNow;
        }
    }
}
