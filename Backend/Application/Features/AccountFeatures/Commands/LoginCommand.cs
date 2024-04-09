using Application.Services;
using Domain.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands
{
    public class LoginCommand : IRequest<object>
    {
        public LoginDTO LoginDTO { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, object>
        {
            private readonly UserManager<User> userManager;
            private readonly TokenService tokenService;

            public LoginCommandHandler(UserManager<User> userManager, TokenService tokenService)
            {
                this.userManager = userManager;
                this.tokenService = tokenService;
            }

            public async Task<object> Handle(LoginCommand command, CancellationToken cancellationToken)
            {
                var user = await userManager.FindByNameAsync(command.LoginDTO.UserName);

                if (user == null || !await userManager.CheckPasswordAsync(user, command.LoginDTO.Password))
                {
                    return new
                    {
                        message = "Email or password is not correct",
                        status = 0,
                        DT = (object)null
                    };
                }
                return new
                {
                    message = "Log in successfully",
                    status = 1,
                    DT = new UserDTO()
                    {
                        UserName = user.UserName,
                        Token = await tokenService.GenerateToken(user),
                    }
                };
            }
        }
    }
}
