using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Repostories
{
    public class ProductReadRepository : ReadRepostory<Product>, IProductReadRepository
    {
        public ProductReadRepository(CarrierAPIContext context) : base(context)
        {
        }
    }
}
