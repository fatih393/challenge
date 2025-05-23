using CarrierAPI.Application.DTOs;

namespace CarrierAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public string Message { get; set; }
        public Token Token{ get; set; }
    }
}