using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Carrier
{
    public class RemoveCarrierEvent: BaseEntitiy
    {
        public DateTime CarrierDate { get; set; }
        public string Message { get; set; }
        public RemoveCarrierEvent(int id)
        {
            Id = id;
            CarrierDate = DateTime.UtcNow;
            Message = id + " numaralı kargo firmasi silindi";
        }

        
    }
}
