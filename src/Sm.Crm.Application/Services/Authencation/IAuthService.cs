namespace Sm.Crm.Application.Services.Authencation
{
    public interface IAuthService:IInternalAuthencation, IExternalAuthencation
    {
        Task ResetPasswordAsync(string email);
    }
}
