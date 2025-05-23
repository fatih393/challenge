using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Abstractions.Token;
using CarrierAPI.Application.DTOs;
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
        readonly IAuthService _authService;
        readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(IAuthService authService, ILogger<LoginUserCommandHandler> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kullanıcı girişi");
           var token = await _authService.LoginAsync(request.UserName, request.Password, 30);
            return new()
            {
                Token = token,
            };
        }
    }
}
