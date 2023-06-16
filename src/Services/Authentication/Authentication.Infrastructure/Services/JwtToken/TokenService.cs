using Authentication.Application.Contract.JwtToken;
using Authentication.Domain.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Services.JwtToken
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public TokenService(IUserRepository userRepository, IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        public async Task<string> CreateToken(IdentityUser user)
        {
            var roles = await GetUserRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };
            claims.AddRange(await GetUserClaimsAsync(user));
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList());
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(_configuration["Jwt:PrivateKey"]), out _);
            var creds = new SigningCredentials(new RsaSecurityKey(rsa),SecurityAlgorithms.RsaSha256);
           
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var rsa = _serviceProvider.GetRequiredService<RsaSecurityKey>();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = rsa,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;
                return userId;
            }
            catch
            {
                return null;
            }
        }



        private async Task<IList<Claim>> GetUserClaimsAsync(IdentityUser user)
            => await _userRepository.GetClaimsAsync(user);

        private async Task<IList<string>> GetUserRolesAsync(IdentityUser user)
            => await _userRepository.GetRolesAsync(user);


    }
}
