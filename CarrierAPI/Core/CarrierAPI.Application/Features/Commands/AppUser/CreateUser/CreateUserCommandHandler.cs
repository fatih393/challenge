using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
       readonly IUserService _userService;
        readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserService userService, ILogger<CreateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kullanıcı oluşturuldu");
            CreateUserResponse serviceResponse = await _userService.CreateAsync(new()
            {
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.UserName,
            });

            return new()
            {
                Message = serviceResponse.Message,
                Succeeded = serviceResponse.Succeeded
            };



        }
    }
}
