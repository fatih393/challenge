using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.CarrierConfigurationEvent
{
    public class GetCarrierConfigurationsEvent
    {
        public DateTime CarrierConfigurationsDate { get; set; }
        public string Message { get; set; }
        public GetCarrierConfigurationsEvent()
        {
            CarrierConfigurationsDate = DateTime.UtcNow;
            Message = "Konfigurasyonlar listelendi";
        }

       

    }
}
