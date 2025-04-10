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
    public class CarrierReadRepository : ReadRepostory<Carrier>, ICarrierReadRepository
    {
        public CarrierReadRepository(CarrierAPIContext context) : base(context)
        {
        }
    }
}
