using MediatR;

namespace CarrierAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequest: IRequest<CreateUserCommandResponse>
    {
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}