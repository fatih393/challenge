using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Events.Order
{
    public class PostOrdersEvent: BaseEntitiy
    {
        public DateTime OrderDate { get; set; }
        public int OrderDesi { get; set; }
        public string Message { get; set; }
        public PostOrdersEvent(int id, int orderDesi)
        {
            Id = id;
            OrderDate = DateTime.UtcNow;
            Message = id + " numaralı " + orderDesi + " desili sipariş alındı";
            OrderDesi = orderDesi;
        }

    }
}
