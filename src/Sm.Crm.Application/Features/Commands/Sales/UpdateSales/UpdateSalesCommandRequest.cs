using MediatR;

namespace Sm.Crm.Application.Features.Commands.Sales.UpdateSales
{
    public class UpdateSalesCommandRequest:IRequest<UpdateSalesCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public int? EmployeeUserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleAmount { get; set; }
        public string Description { get; set; }
    }
}