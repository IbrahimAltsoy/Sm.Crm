namespace Sm.Crm.Application.DTOs.Customers
{
    public class CustomerUpdateDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string IdentityNumber { get; set; } = null!;
    }
}
