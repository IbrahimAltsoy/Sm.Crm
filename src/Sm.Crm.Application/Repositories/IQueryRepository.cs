using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Entities.BaseEntity;
using System.Linq.Expressions;

namespace Sm.Crm.Application.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool tracking);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking);
        Task<T> GetByIdAsync(int id, bool tracking);
    }
}
