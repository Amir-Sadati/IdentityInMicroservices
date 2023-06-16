using Authentication.Application.Contract.JwtToken;
using Authentication.Application.Dtos.UserDtos;
using Authentication.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedKernel.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.UserFeature.Commands
{
    public record UserRevokeTokenCommand(TokenDto TokenDto) : IRequest<Result<Unit>>;
    
    public class UserRevokeTokenCommandHandler : IRequestHandler<UserRevokeTokenCommand, Result<Unit>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;

        public UserRevokeTokenCommandHandler(IHttpContextAccessor httpContextAccessor,ITokenService tokenService)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
        }

        public async Task<Result<Unit>> Handle(UserRevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tokenUserId = _tokenService.ValidateToken(request.TokenDto.Token);
            if (userId != tokenUserId)
                return Result<Unit>.Failure("Revoke failed");

            _ = RevokeToken.RevokeTokenList.TryGetValue(userId,out List<string>? userRevokeTokens);
            if (userRevokeTokens==null)
                RevokeToken.RevokeTokenList.Add(userId, new() { request.TokenDto.Token });

            else
                RevokeToken.RevokeTokenList[userId].Add(request.TokenDto.Token);
            return Result<Unit>.Success(Unit.Value);
            
        }
    }
}
