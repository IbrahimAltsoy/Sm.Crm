using MediatR;

namespace Sm.Crm.Application.Features.Commands.Sales.CreateSales
{
    public class CreateSalesCommandRequest:IRequest<CreateSalesCommandResponse>
    {
        public string Name { get; set; }
        //public int? RequestId { get; set; }
        public int? EmployeeUserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleAmount { get; set; }
        public string Description { get; set; }
    }
}