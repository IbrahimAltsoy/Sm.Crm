using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Sales.CreateSales
{
    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommandRequest, CreateSalesCommandResponse>
    {
        readonly ICommandRepository<Sale, int> _commandRepository;

        public CreateSalesCommandHandler(ICommandRepository<Sale, int> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<CreateSalesCommandResponse> Handle(CreateSalesCommandRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.Create(new()
            {
                Name = request.Name,
                Description = request.Description,
                SaleAmount = request.SaleAmount,
                SaleDate = request.SaleDate,                
                EmployeeUserId = request.EmployeeUserId

            });
            return new()
            {
                Message = "Kayıt başarılı bir şekilde gerçekleşti"
            };
        }
    }
}
