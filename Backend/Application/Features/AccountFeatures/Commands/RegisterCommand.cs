using Application.Features.CartItemFeatures.Commands;
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
    public class RegisterCommand : IRequest<object>
    {
        public RegisterDTO RegisterDTO { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, object>
        {
            private readonly UserManager<User> userManager;

            public RegisterCommandHandler(UserManager<User> userManager)
            {
                this.userManager = userManager;
            }

            public async Task<object> Handle(RegisterCommand command, CancellationToken cancellationToken)
            {
                var user = new User { UserName = command.RegisterDTO.UserName, Email = command.RegisterDTO.Email };

                var result = await userManager.CreateAsync(user, command.RegisterDTO.Password);

                if (!result.Succeeded)
                {
                    return new
                    {
                        message = string.Join(", ", result.Errors.Select(e => e.Description)),
                        status = 0,
                        DT = (object)null,
                    };
                }

                //Assign to new role
                await userManager.AddToRoleAsync(user, "Member");
                return new
                {
                    message = "Create new user successfully",
                    status = 1,
                    DT = (object)user,
                };
            }
        }
    }
}
