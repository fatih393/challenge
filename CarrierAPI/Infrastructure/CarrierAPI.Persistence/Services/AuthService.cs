using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Abstractions.Token;
using CarrierAPI.Application.DTOs;
using CarrierAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService, IConfiguration configuration, SignInManager<AppUser> signInManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _configuration = configuration;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["Google:Audience"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    Random rnd = new Random();
                    user = new()
                    {
                        Id = rnd.Next(1, int.MaxValue),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name,
                    };
                    var idendityResult = await _userManager.CreateAsync(user);
                    result = idendityResult.Succeeded;
                }

            }
            if (result)
                await _userManager.AddLoginAsync(user, info);
            else
                throw new Exception("Invalid ecternal authentication");
            Token token = _tokenHandler.CreateAccessToken(30);
            await _userService.UpdateRefreshToken(token.RefreshToken, user.Id, token.Expiration, 10);
            return token;
        }


        public async Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
                throw new Exception("Kullanıcı veya şifre hatalı");

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, password, false);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false);

                var name = _contextAccessor.HttpContext?.User?.FindFirst("name")?.Value;

                Token token = _tokenHandler.CreateAccessToken(30);
                await _userService.UpdateRefreshToken(token.RefreshToken, appUser.Id, token.Expiration, 10);
                return token;
            }

            throw new Exception("Kullanıcı veya şifre hatalı"); 
        }


        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(30);
                await _userService.UpdateRefreshToken(token.RefreshToken, user.Id, token.Expiration, 10);
                return token;
            }
            else
                throw new Exception("Kullanıcı refresh token için bulunamadı");
        }
    }
}
