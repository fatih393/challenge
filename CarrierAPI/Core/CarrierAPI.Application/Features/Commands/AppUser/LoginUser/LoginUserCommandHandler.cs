using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManeger;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signinManeger;
        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManeger, SignInManager<Domain.Entities.Identity.AppUser> signinManeger)
        {
            _userManeger = userManeger;
            _signinManeger = signinManeger;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser appUser = await _userManeger.FindByNameAsync(request.UserName);
            if (appUser == null)
                throw new Exception("Kullanıcı veya şifre hatalı");
           SignInResult result= await _signinManeger.CheckPasswordSignInAsync(appUser, request.Password, false);

            if (result.Succeeded)
                return new()
                {
                    Message = "Giriş başarılı"
                };

            return new()
            {
                Message= "Giriş başarısız"
            };
        }
    }
}
