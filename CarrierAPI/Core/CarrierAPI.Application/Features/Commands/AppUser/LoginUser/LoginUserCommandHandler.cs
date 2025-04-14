using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly IHttpContextAccessor _contextAccessor;
        readonly ILogger<LoginUserCommandHandler> _logger;
        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManeger, SignInManager<Domain.Entities.Identity.AppUser> signinManeger, IHttpContextAccessor contextAccessor, ILogger<LoginUserCommandHandler> logger)
        {
            _userManeger = userManeger;
            _signinManeger = signinManeger;
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kullanıcı girişi");
            var appUser = await _userManeger.FindByNameAsync(request.UserName);
            if (appUser == null)
                throw new Exception("Kullanıcı veya şifre hatalı");

            var result = await _signinManeger.CheckPasswordSignInAsync(appUser, request.Password, false);

            if (result.Succeeded)
            {
                await _signinManeger.SignInAsync(appUser, isPersistent: false); 

                var name = _contextAccessor.HttpContext?.User?.FindFirst("name")?.Value;

                return new()
                {
                    Message = $"Giriş başarılı, hoş geldin {name}"
                };
            }

            return new()
            {
                Message = "Giriş başarısız"
            };
        }
    }
}
