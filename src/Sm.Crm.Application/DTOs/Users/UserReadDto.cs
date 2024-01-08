namespace Sm.Crm.Application.DTOs.Users
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }        
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; }
        public string ActivationKey { get; set; }
        public string IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }

    }
}
