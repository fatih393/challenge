using MediatR;

namespace CarrierAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest: IRequest<LoginUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}