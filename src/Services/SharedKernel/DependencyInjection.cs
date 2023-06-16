using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public static class DependencyInjection
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RsaSecurityKey>(provider =>
            {
                RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(configuration["Jwt:PublicKey"]),
                    bytesRead: out int _
                );

                return new RsaSecurityKey(rsa);
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(opt =>
              {
                  var rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();
                  opt.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = rsa,
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero

                  };
              }
              );

        }
    }
}
