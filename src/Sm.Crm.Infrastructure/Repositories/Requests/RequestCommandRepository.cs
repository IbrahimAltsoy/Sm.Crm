using Microsoft.EntityFrameworkCore;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Repositories.Requests;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Infrastructure.Persistence;
using Sm.Crm.Infrastructure.Repositories;

namespace Sm.Crm.Infrastructure.Repositories.Requests
{
    public class RequestCommandRepository : CommandRepository<Request, int>,IRequestCommandReposityory
    {
        readonly IQueryRepository<Request, int> _queryRepository;
        readonly ApplicationDbContext _context;
        
        public RequestCommandRepository(ApplicationDbContext context, IQueryRepository<Request, int> queryRepository) : base(context)
        {
            _queryRepository = queryRepository;
            _context = context;
        }

       

        public async Task RequestStatusChangeAsync(int id)
        {
            var value = await _queryRepository.GetByIdAsync(id);
            if (value != null)
            {
                value.Description = value.Description;
                value.CustomerUserId = value.CustomerUserId;
                value.EmployeeUserId = value.EmployeeUserId;
                if (value.RequestStatusId==1)
                {                    
                    value.RequestStatusId = 0;                   
                }
                else value.RequestStatusId = 1;
                _context.Update(value);
                await _context.SaveChangesAsync();
                return;

            }
            else
            {
                return;
            }
           
           
        }


    }
}
