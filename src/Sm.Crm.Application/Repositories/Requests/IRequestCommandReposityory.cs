using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Repositories.Requests
{
    public interface IRequestCommandReposityory: ICommandRepository<Request, int>
    {
        Task RequestStatusChangeAsync(int id);
    }
}
