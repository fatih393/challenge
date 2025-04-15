using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Order
{
    public class GetOrdersEvent : BaseEntitiy
    {
        public DateTime OrderDate { get; set; }
        public GetOrdersEvent()
        {
            OrderDate = DateTime.UtcNow;
        }
    }
}
