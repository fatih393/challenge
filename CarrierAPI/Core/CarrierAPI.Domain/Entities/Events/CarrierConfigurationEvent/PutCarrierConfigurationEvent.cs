using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent
{
    public class PutCarrierConfigurationEvent : BaseEntitiy
    {
        public DateTime CarrierConfigurationDate { get; set; }
        public string Message { get; set; }
       
        public PutCarrierConfigurationEvent(int id)
        {
            Id = id;
            Message = id + " numaralı  konfigürasyon güncellendi";
        }
    }
}
