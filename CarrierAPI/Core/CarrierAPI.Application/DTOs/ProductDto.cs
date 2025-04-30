using CarrierAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.DTOs
{
    public class ProductDto: BaseEntitiy
    {
        public string Name { get; set; }
    }
}
