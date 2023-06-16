using Catalog.Domain.Common.Interfaces;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
using Catalog.Infrastructure.PolicyAuthorization;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCatalogInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));
            services.AddScoped<ICatalogCatalogUnitOfWork, CatalogUnitOfWork>();
            services.AddJwtAuthentication(configuration);
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminProduct", policy => policy.Requirements.Add(new AdminProductRequirement()));
                opt.AddPolicy("PD", policy => policy.RequireClaim("Services", "PD"));
            });
            services.AddSingleton<IAuthorizationHandler, AdminProductRequirementHandler>();

            services.AddHttpClient("AuthenticationApi", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("AuthenticationUrl").Value);
            });
            return services;
        }
    }
}
