using Application.Features.AccountFeatures.Commands;
using Application.Features.CategoryFeatures.Commands;
using Application.Services;
using Domain.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;

        public AccountController(UserManager<User> userManager, TokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateNewUser(RegisterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                return Ok(new
                {
                    message = "Getting current user successfully",
                    status = 1,
                    DT = new UserDTO
                    {
                        UserName = user.UserName,
                        Token = await tokenService.GenerateToken(user),
                    }
                });
            }
            else
            {
                return NotFound(new
                {
                    message = "User not found",
                    status = 0
                });
            }
        }

    }
}
