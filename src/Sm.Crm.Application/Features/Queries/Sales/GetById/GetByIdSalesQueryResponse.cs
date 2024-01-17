namespace Sm.Crm.Application.Features.Queries.Sales.GetById
{
    public class GetByIdSalesQueryResponse
    {
        public string Name { get; set; }
        public int? RequestId { get; set; }
        public int? EmployeeUserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleAmount { get; set; }
        public string Description { get; set; }
    }
}