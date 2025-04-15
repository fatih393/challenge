using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Order
{
    public class RemoveOrdersEvent : BaseEntitiy
    {
        public DateTime OrderDate { get; set; }
        public string Message { get; set; }
        public RemoveOrdersEvent(int id)
        {
            Id = id;
            OrderDate = DateTime.UtcNow;
            Message = id + " numaralı sipariş silindi";
        }
    }
}
