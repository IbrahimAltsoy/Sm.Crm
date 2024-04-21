namespace Sm.Crm.Application.Hubs
{
    public interface ILoginHubService
    {
        Task UserLoginSendMessageAsync(string? email, string subject, string? body);
    }
}
