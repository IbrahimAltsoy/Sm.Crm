namespace Sm.Crm.Application.DTOs.Customers
{
    public class CustomerUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string IdentityNumber { get; set; } = null!;
    }
}
