using Sm.Crm.Domain.Common;

namespace Sm.Crm.Domain.Entities;

public class User : BaseEntity<int>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Roles { get; set; }
    public string ActivationKey { get; set; }
    public string IsActive { get; set; }

    // Navigation properties
    public Customer CustomerFk { get; set; }
}