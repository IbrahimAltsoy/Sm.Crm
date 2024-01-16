using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Common;
using Sm.Crm.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Sm.Crm.Infrastructure.Repositories
{
    public class QueryRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
        private readonly ApplicationDbContext _context;

        public QueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public DbSet<TEntity> Table => _context.Set<TEntity>();



        public IQueryable<TEntity> GetAll(bool? tracking = false)
        {
            var query = Table.AsQueryable();
            if (tracking==false)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetByIdAsync(TKey id, bool? tracking)
        {
            var query = Table.AsQueryable();
            if (tracking==false)
                query = query.AsNoTracking();
            //return await query.FirstOrDefaultAsync(p=>p.Id.ToString()==id);
            return await Table.FindAsync(id);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool? tracking=false)
        {
            var query = Table.AsQueryable();
            if (tracking==false)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
               

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool? tracking)
        {
            var query = Table.Where(method);
            if (tracking==false) query = query.AsNoTracking();
            return query;
        }        
    }
}