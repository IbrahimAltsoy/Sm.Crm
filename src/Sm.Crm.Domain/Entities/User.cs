using Microsoft.AspNetCore.Identity;
using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class User : IdentityUser<int>, IEntity<int>
{
    //public string Username { get; set; }
    //public string Email { get; set; }
    //public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Roles { get; set; }
    public string? ActivationKey { get; set; }
    public string? IsActive { get; set; }

  
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }

    // Navigation properties
    public Customer CustomerFk { get; set; }
}

