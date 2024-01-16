using MediatR;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Repositories.Customers;
using Sm.Crm.Application.Services.Customers;
using Sm.Crm.Domain.Enums;

namespace Sm.Crm.Application.Features.Queries.Customers.CustomerGetAll
{
    public class CustomerGetAllQeryHandler : IRequestHandler<CustomerGetAllQeryRequest, CustomerGetAllQeryResponse>
    {
        readonly ICustomerService _customerService;
        readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerGetAllQeryHandler(ICustomerService customerService, ICustomerQueryRepository customerQueryRepository)
        {
            _customerService = customerService;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<CustomerGetAllQeryResponse> Handle(CustomerGetAllQeryRequest request, CancellationToken cancellationToken)
        {
            var totalCustomerCount = _customerQueryRepository.GetAllCustomer().Count();

            var customers = _customerQueryRepository.GetAllCustomer().Skip(request.Page * request.Size).Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.IdentityNumber,
                    p.CompanyName

                }).ToList();

            return new()
            {
                Customers = customers,
                TotalCustomerCount = totalCustomerCount
            };
            
        }
    }
}


