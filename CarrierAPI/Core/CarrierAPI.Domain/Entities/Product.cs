using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities
{
    public class Product: BaseEntitiy
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int? OrderId { get; set; }


    }
}
