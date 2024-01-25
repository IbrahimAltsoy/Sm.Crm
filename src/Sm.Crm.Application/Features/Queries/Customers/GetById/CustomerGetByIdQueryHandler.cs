using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Queries.Customers.GetById
{
    public class CustomerGetByIdQueryHandler : IRequestHandler<CustomerGetByIdQueryRequest, CustomerGetByIdQueryResponse>
    {
        readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerGetByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<CustomerGetByIdQueryResponse> Handle(CustomerGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            //var employe = await _queryRepository.GetByIdAsync(request.Id, false);

            //return new()
            //{

            //    Name = employe.Name,
            //    Surname = employe.Surname,
            //    IdentityNumber = employe.IdentityNumber,
            //    Phone = employe.Phone,
            //    Email = employe.Email,
            //    PhotoPath = employe.PhotoPath
            //};
            var customer = await _customerQueryRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = customer.Id.ToString(),
                CompanyName = customer.CompanyName,
                IdentityNumber = customer.IdentityNumber
            };
        }
    }
}
