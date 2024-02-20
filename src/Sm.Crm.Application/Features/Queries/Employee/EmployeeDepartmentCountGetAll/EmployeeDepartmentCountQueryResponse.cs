using System.Resources;

namespace Sm.Crm.Application.Features.Queries.Employee.EmployeeDepartmentCountGetAll
{
    public class EmployeeDepartmentCountQueryResponse
    {
        public int Administration {  get; set; }
        public int Sale {  get; set; }
        public int Marketing {  get; set; }
        public int Accounting {  get; set; }
        public int Technical {  get; set; }
        public int HumanResourcesUnit {  get; set; }
    }
}