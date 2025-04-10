﻿using CarrierAPI.Application.Repostories;
using CarrierAPI.Domain.Entities.Common;
using CarrierAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Repostories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntitiy
    {
        readonly private CarrierAPIContext _context;

        public WriteRepository(CarrierAPIContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry= await Table.AddAsync(model);
            return entityEntry.State== EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State!= EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == int.Parse(id));
            return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);   
            return true;
        }

        public async Task<int> Saveasync()
        => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
