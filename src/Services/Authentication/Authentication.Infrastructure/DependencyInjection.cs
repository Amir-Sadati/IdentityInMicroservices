using Authentication.Application.Contract.JwtToken;
using Authentication.Domain.Common.Interfaces;
using Authentication.Infrastructure.Persistence;
using Authentication.Infrastructure.Persistence.Repositories;
using Authentication.Infrastructure.Services.JwtToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Authentication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationInfrastructureServices
          (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("AuthenticationConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            AddIdentityServices(services);
            services.AddJwtAuthentication(configuration);

            return services;

        }
        private static void AddIdentityServices (IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
                //options.SignIn.RequireConfirmedPhoneNumber = false
            })
           .AddEntityFrameworkStores<AuthenticationDbContext>()
           .AddDefaultTokenProviders();

           

        }        
        
    }
}
