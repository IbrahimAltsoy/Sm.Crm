using MediatR;
using Sm.Crm.Application.DTOs.Employies;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Repositories;
using E = Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Employee.GetById
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        readonly IQueryRepository<E.Employee, int> _queryRepository;


        public GetByIdEmployeeQueryHandler(IQueryRepository<E.Employee, int> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var employe = await _queryRepository.GetByIdAsync(request.Id, false);

            return new()
            {
               
                Name = employe.Name,
                Surname = employe.Surname,
                IdentityNumber = employe.IdentityNumber,
                Phone = employe.Phone,
                Email = employe.Email,
                PhotoPath = employe.PhotoPath
            };
        }
    }
}
