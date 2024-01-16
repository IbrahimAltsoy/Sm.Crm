using Sm.Crm.Domain.Common;

namespace Sm.Crm.Application.Repositories
{
    public interface ICommandRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    {
       
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task DeleteById(TKey id);
        Task SoftDelete(TEntity entity);


    }
}
