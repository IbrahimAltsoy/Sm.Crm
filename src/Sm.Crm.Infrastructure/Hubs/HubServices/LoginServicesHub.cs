using Microsoft.AspNetCore.SignalR;
using Sm.Crm.Application.Hubs;
using Sm.Crm.Application.Services.Email;
using A =Sm.Crm.Infrastructure.Hubs.LoginHub;
namespace Sm.Crm.Infrastructure.Hubs.HubServices
{
    public class LoginServicesHub : ILoginHubService
    {
        readonly IHubContext<A.LoginHub> _context;
        readonly IEmailService _emailService;

        public LoginServicesHub(IHubContext<A.LoginHub> context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task UserLoginSendMessageAsync(string email, string subject, string body)
        {
            await _context.Clients.All.SendAsync(subject);
           await _emailService.SendMailAsync(email,subject, body);
        }
    }
}
