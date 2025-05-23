using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.DTOs.User;
using CarrierAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                UserName = model.UserName,
                NameSurname = model.NameSurname
            }, model.Password);
            CreateUserResponse response = new() { Succeeded = result.Succeeded};
            if (result.Succeeded)
                response.Message = "kullanıcı başarıyla oluşturuldu";
            else
                response.Message = "kullanıcı oluşturulamadı";
            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, int userId, DateTime accessTokenDate, int refreshTokenLifeTime)
        {
            AppUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(refreshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
