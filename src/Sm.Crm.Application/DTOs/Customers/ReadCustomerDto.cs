namespace Sm.Crm.Application.DTOs.Customers
{
    public class ReadCustomerDto
    {
        public int UserId { get; set; }

        public string IdentityNumber { get; set; } = null!;

        public int? GenderId { get; set; }

        public int? StatusTypeId { get; set; }

        public short? CustomerType { get; set; }

        public int? TitleId { get; set; }

        public string? CompanyName { get; set; }

        public int? RegionId { get; set; }

        public DateOnly? BirthDate { get; set; }
    }
}
