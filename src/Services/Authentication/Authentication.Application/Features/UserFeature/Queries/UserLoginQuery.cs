using Authentication.Application.Contract.JwtToken;
using Authentication.Application.Dtos.UserDtos;
using Authentication.Domain.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.UserFeature.Queries
{
    public record UserLoginQuery(UserLoginDto LoginDto) : IRequest<Result<UserTokenDto>>;

    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, Result<UserTokenDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserLoginQueryHandler(IUserRepository userRepository,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<Result<UserTokenDto>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.FindByNameAsync(request.LoginDto.UserName);
            if (user==null)
                return Result<UserTokenDto>.Failure("Incorrect username or password");
              
            var signInResult = await _userRepository.CheckPasswordSignInAsync
                (user, request.LoginDto.Password);

            if (signInResult.Succeeded)
               return Result<UserTokenDto>.Success
                    (new UserTokenDto(await _tokenService.CreateToken(user),user.Id));

            return Result<UserTokenDto>.Failure("Incorrect username or password");
        }
    }


}
