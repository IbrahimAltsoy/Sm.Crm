namespace Sm.Crm.Application.Features.Queries.Requests.GetById
{
    public class GetByIdRequestQueryResponse
    {
        public string Description { get; set; }
        public int RequestStatusId { get; set; }
        public int EmployeeUserId { get; set; }
        public int CustomerUserId { get; set; }
    }
}
