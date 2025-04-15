using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Carrier
{
    public class PostCarrierEvent: BaseEntitiy
    {
        public DateTime CarrierDate { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public PostCarrierEvent(int id, string name)
        {
            Id = id;
            CarrierDate = DateTime.UtcNow;
            Message = "Kargo firması eklendi";
            Name = name;
        }

       
        
    
    }
}
