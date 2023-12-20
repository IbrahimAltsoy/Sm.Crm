

using Microsoft.EntityFrameworkCore;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Domain.Entities.BaseEntity;

namespace Sm.Crm.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }

    }
}
