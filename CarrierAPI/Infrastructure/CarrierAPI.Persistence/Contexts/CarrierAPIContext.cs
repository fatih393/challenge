using CarrierAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Contexts
{
    public class CarrierAPIContext :DbContext
    {
        public CarrierAPIContext(DbContextOptions options): base(options) { }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
