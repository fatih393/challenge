using CarrierAPI.Domain.Entities;
using CarrierAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Contexts
{
    public class CarrierAPIContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public CarrierAPIContext(DbContextOptions options): base(options) { }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
