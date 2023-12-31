﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Common;
using Sm.Crm.Infrastructure.Persistence;


namespace Sm.Crm.Infrastructure.Repositories
{
    public class QueryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _table;

        public QueryRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        
        public async Task<List<TEntity>> GetAll()
        {
            
             return await _table.ToListAsync();
        }

        public async Task<TEntity?> GetById(TKey id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Update(TEntity entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Delete(TEntity entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
            return;
        }


        public async Task DeleteById(TKey id)
        {
            var entity = await _table.FindAsync(id);
            if (entity != null) await Delete(entity);
        }

        public async Task SoftDelete(TEntity entity)
        {
            var entityItem = await GetById(entity.Id);
            if (entity is not BaseAuditableEntity) return;
            if (entityItem is null) return;

            (entityItem as BaseAuditableEntity).DeletedAt = DateTime.UtcNow;

            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}