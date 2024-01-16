using Sm.Crm.Domain.Common;
using System.Linq.Expressions;

namespace Sm.Crm.Application.Repositories
{
    public interface IQueryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
       
        IQueryable<TEntity> GetAll(bool? tracking=false);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool? tracking=false);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool? tracking=false);
        Task<TEntity> GetByIdAsync(TKey id, bool? tracking=false);
    }
}
