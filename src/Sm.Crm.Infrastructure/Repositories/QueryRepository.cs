using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Entities.BaseEntity;
using Sm.Crm.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Sm.Crm.Infrastructure.Repositories
{
    public class QueryRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext _context;

        public QueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
               

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking)
        {
           
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }


        public async Task<T> GetByIdAsync(int id, bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking)
        {
            var query = Table.Where(method);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }
    }
}
