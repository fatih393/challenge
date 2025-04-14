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
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ILogger<CreateUserCommandHandler> _logger;
        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ILogger<CreateUserCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kullanıcı oluşturuldu");
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                UserName = request.UserName,
                NameSurname = request.NameSurname
            }, request.Password);

            return new CreateUserCommandResponse(result.Succeeded);
        }
    }
}
