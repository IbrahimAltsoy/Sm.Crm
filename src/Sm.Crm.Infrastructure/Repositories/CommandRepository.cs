using Microsoft.EntityFrameworkCore;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Domain.Common;
using Sm.Crm.Application.Repositories;

namespace Sm.Crm.Infrastructure.Repositories
{
    public class CommandRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _table;

        public CommandRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll(int page = 1)
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