using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities
{
    public class Carrier: BaseEntitiy
    {
        public string CarrierName { get; set; }
        public bool CarriersActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
       // public int CarrierConfigurationId { get; set; }  BUNUN NE İŞE YARADIĞINI ANLAMADIM
        public ICollection<Order> Orders { get; set; }
        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
