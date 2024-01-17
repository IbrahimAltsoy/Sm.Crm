using MediatR;
using Sm.Crm.Application.Repositories;
using Sm.Crm.Domain.Entities;

namespace Sm.Crm.Application.Features.Commands.Sales.UpdateSales
{
    public class UpdateSalesCommandHandler : IRequestHandler<UpdateSalesCommandRequest, UpdateSalesCommandResponse>
    {
        readonly ICommandRepository<Sale, int> _commandRepository;
        readonly IQueryRepository<Sale, int> _queryRepository;

        public UpdateSalesCommandHandler(ICommandRepository<Sale, int> commandRepository, IQueryRepository<Sale, int> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<UpdateSalesCommandResponse> Handle(UpdateSalesCommandRequest request, CancellationToken cancellationToken)
        {
            Sale sale = await _queryRepository.GetByIdAsync(request.Id);
            if (sale == null) return new() { Message = "Güncelleme oluştururken bir hata oluştu" };
            else
            {
                sale.Name = request.Name;
                sale.Description = request.Description;
                sale.SaleAmount = request.SaleAmount;
                sale.SaleDate = request.SaleDate;               
                sale.EmployeeUserId = request.EmployeeUserId;
                await _commandRepository.Update(sale);
                return new() { Message = "Güncelleme başarıyla gerçekleşti" };
            }
            
        }
    }
}
