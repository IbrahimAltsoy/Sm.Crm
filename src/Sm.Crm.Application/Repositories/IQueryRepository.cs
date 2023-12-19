using Sm.Crm.Domain.Entities;
using System.Linq.Expressions;

namespace Sm.Crm.Application.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll(bool tracking);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking);
        //Task<T> GetByIdAsync(string id, bool tracking);
    }
}
