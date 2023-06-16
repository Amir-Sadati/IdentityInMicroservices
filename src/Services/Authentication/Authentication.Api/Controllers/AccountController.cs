using Authentication.Application.Dtos.UserDtos;
using Authentication.Application.Features.UserFeature.Commands;
using Authentication.Application.Features.UserFeature.Queries;
using Authentication.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{

    public class AccountController : BaseAuthenticationApiController
    {
        [HttpPost("Token")]
        public async Task<IActionResult> Token(UserLoginDto loginDto)
            => HandleResult(await Mediator.Send(new UserLoginQuery(loginDto)));

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
            => HandleResult(await Mediator.Send(new UserRegisterCommand(registerDto)));

        [Authorize]
        [HttpPost("Revoke")]
        public async Task<IActionResult> Revoke(TokenDto tokenDto)
         => HandleResult(await Mediator.Send(new UserRevokeTokenCommand(tokenDto)));

        
        [HttpGet("Revoke/{userId}")]
        public async Task<IActionResult> Revoke(string userId)
        {
            var userRevokeTokens = RevokeToken.RevokeTokenList.TryGetValue(userId, out var revokeTokens);
            return Ok(revokeTokens??new List<string>());
        }

    }
}
