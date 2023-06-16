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

namespace Authentication.Application.Features.UserFeature.Commands
{
    public record UserRegisterCommand(UserRegisterDto UserRegisterDto) : IRequest<Result<Unit>>;

    public class RegisterUserCommandHandler : IRequestHandler<UserRegisterCommand, Result<Unit>>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Unit>> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
           var user = await _userRepository.CreateAsync(
                new IdentityUser(request.UserRegisterDto.UserName), 
                request.UserRegisterDto.Password);
            if (user.Succeeded)
                return Result<Unit>.Success(Unit.Value);

            return Result<Unit>.Failure("Registration failed");

        }
    }



}
