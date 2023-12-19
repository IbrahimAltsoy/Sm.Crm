

using Microsoft.EntityFrameworkCore;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        DbSet<T> Table { get; }

    }
}
