using Sm.Crm.Domain.Common;

namespace Sm.Crm.Application.Repositories
{
    public interface IQueryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
        Task<List<TEntity>> GetAll(int page = 1);
        Task<TEntity?> GetById(TKey id);
    }
}
