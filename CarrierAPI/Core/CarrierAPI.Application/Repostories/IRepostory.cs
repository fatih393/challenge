using CarrierAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Repostories
{
    public interface IRepostory<T> where T : BaseEntitiy
    {
        DbSet<T> Table { get; }
    }
}
