using Microsoft.EntityFrameworkCore;

namespace Sm.Crm.Application.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
       
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int>
    {
    }
}