using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.PolicyAuthorization
{
    public record AdminProductRequirement : IAuthorizationRequirement;
    

    public class AdminProductRequirementHandler : AuthorizationHandler<AdminProductRequirement>
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public AdminProductRequirementHandler(IHttpClientFactory httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminProductRequirement requirement)
        {
            var IsAdmin = context.User.Claims.Any
                (x => x.Type == ClaimTypes.Role && x.Value == "Admin");

            if (!IsAdmin)
            {
                context.Fail();
                return;
            }
            var hasProductClaim = context.User.Claims.Any(x => x.Type == "Services" && x.Value == "PD");

            if(!hasProductClaim)
            {
                context.Fail();
                return;
            }

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var httpContext = context.Resource as HttpContext;
            var token = httpContext.Request.Headers["Authorization"].ToString().Split(" ").Last();

            var response = await _httpClient.CreateClient
                ("AuthenticationApi").GetAsync($"api/Account/Revoke/{userId}");
       
            var revokeTokens = await response.Content.ReadFromJsonAsync<List<string>>();
          
            if (revokeTokens.Contains(token))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
            await Task.CompletedTask;
        }
    }


}
