using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Carrier
{
    public class PutCarrierEvent: BaseEntitiy
    {
        public DateTime CarrierDate { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public PutCarrierEvent(int id, string name)
        {
            Id = id;
            Name = name;
            CarrierDate = DateTime.UtcNow;
            Message = "Kargo firması güncellendi";
         
        }

        
    
    }
}
