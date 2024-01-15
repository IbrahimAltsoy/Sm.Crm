using MediatR;

namespace Sm.Crm.Application.Features.Commands.Users.GoogleLogin
{
    public class GoogleLoginCommandRequest:IRequest<GoogleLoginCommandResponse>
    {
        public string Id { get; set; }
        public string IdToken { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Provider { get; set; }
        
        public string? Surname { get; set; }
        //public string? UserName { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string? Password { get; set; }
    }
}

//Id = new(),
