using Microsoft.EntityFrameworkCore;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Domain.Common;
using Sm.Crm.Application.Repositories;

namespace Sm.Crm.Infrastructure.Repositories
{
    public class CommandRepository<TEntity, TKey> : ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
        private readonly ApplicationDbContext _context;
        
       

        public CommandRepository(ApplicationDbContext context)
        {
            _context = context;
           
            
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();
      
        public async Task Create(TEntity entity)
        {
            Table.Add(entity);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Update(TEntity entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Delete(TEntity entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
            return;
        }


        public async Task DeleteById(TKey id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null) await Delete(entity);
        }

        public async Task SoftDelete(TEntity entity)
        {
            var entityItem = await Table.FindAsync(entity.Id);
            if (entity is not BaseAuditableEntity) return;
            if (entityItem is null) return;

            (entityItem as BaseAuditableEntity).DeletedAt = DateTime.UtcNow;

            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}