using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Domain.Entities.Item
{
   public  class Item: BaseEntitiy
    {        public string Name { get; set; }
        public string Description { get; set; }
    }
}
