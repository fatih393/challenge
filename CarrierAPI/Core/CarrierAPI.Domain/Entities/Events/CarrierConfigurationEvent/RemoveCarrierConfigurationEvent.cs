using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent
{
    public class RemoveCarrierConfigurationEvent : BaseEntitiy
    {
        public DateTime CarrierConfigurationDate { get; set; }
        public string Message { get; set; }
        public RemoveCarrierConfigurationEvent(int id)
        {
            Id = id;
            CarrierConfigurationDate = DateTime.UtcNow;
            Message = id + " numaralı konfigürasyon silindi";
        }
    }
}
