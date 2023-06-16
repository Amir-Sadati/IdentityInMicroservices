using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddClaimAsync(IdentityUser user, Claim claim);
        Task<IdentityResult> AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims);
        Task<IdentityResult> AddToRoleAsync(IdentityUser user, IEnumerable<string> roles);
        Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role);
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityUser> FindByIdAsync(string userId);
        Task<IdentityUser> FindByNameAsync(string userName);
        Task<IList<Claim>> GetClaimsAsync(IdentityUser user);
        Task<IList<string>> GetRolesAsync(IdentityUser user);
        Task<IdentityResult> UpdateAsync(IdentityUser user);
        Task<SignInResult> CheckPasswordSignInAsync(IdentityUser user, string password);
    }
}
