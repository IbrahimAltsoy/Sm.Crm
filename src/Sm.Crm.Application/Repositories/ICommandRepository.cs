using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Application.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);

        bool Update(T entity);

        bool Delete(T entity);
        Task<bool> DeleteAsync(int id);
        bool DeleteRange(List<T> entities);

        Task<int> SaveChanges();
    }
}
