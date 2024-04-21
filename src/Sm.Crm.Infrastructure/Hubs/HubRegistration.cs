using Microsoft.AspNetCore.Builder;
using A = Sm.Crm.Infrastructure.Hubs.LoginHub;
namespace Sm.Crm.Infrastructure.Hubs
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<A.LoginHub>("/userLogin-hub");
            
        }
    }
}
